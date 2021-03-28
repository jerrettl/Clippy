using Clippy.Entities;
using Clippy.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clippy.Data {
    public class ClippyContext : DbContext
    {
        public ClippyContext(DbContextOptions<ClippyContext> options)
            : base(options)
        {
        }

        public DbSet<Bookmark> Bookmarks { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddBookmarkEntity();
            modelBuilder.AddResourceEntity();
            modelBuilder.AddTagEntity();
            modelBuilder.AddRoleEntity();
            modelBuilder.AddUserEntity();
            modelBuilder.AddNotificationEntity();
            modelBuilder.AddSeedData();
        }

        #region Bookmarks

        public async virtual Task<List<Bookmark>> GetBookmarksAsync()
        {
            return await Bookmarks
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Include(b => b.Tags)
                .AsNoTracking()
                .ToListAsync();
        }

        public async virtual Task<List<Bookmark>> GetPublicBookmarksAsync()
        {
            return await Bookmarks.FromSqlRaw("SELECT * FROM Bookmarks WHERE IsPublic = 1")
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Include(b => b.Tags)
                .ToListAsync();
        }

        public async virtual Task<List<Bookmark>> GetBookmarksByUserIdAsync(int id)
        {
            return await Bookmarks.FromSqlRaw("SELECT * FROM Bookmarks WHERE UserId = {0}", id)
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Include(b => b.Tags)
                .ToListAsync();
        }

        public async virtual Task<List<Bookmark>> GetPublicBookmarksByUserIdAsync(int id)
        {
            return await Bookmarks.FromSqlRaw("SELECT * FROM Bookmarks WHERE UserId = {0} AND IsPublic = 1", id)
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Include(b => b.Tags)
                .ToListAsync();
        }

        public async virtual Task<List<Bookmark>> GetBookmarksBySearch(string query, int id)
        {
            var allPublicBookmarks = from b in Bookmarks
                where b.IsPublic == true
                select b;

            var usersPrivateBookmarks = from b in Bookmarks
                where b.UserId == id && b.IsPublic == false
                select b;

            return await allPublicBookmarks.Union(usersPrivateBookmarks)
                .Where(b => b.Title.ToLower().Contains(query.ToLower()))
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Include(b => b.Tags)
                .ToListAsync();
        }

        public async virtual Task<List<Bookmark>> GetFavoriteBookmarksByUserIdAsync(int id)
        {
            return await Bookmarks.FromSqlRaw("SELECT * FROM Bookmarks WHERE UserId = {0} AND Favorited = 1", id)
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Include(b => b.Tags)
                .ToListAsync();
        }

        public async virtual Task<List<Bookmark>> GetPublicFavoriteBookmarksByUserIdAsync(int id)
        {
            return await Bookmarks.FromSqlRaw("SELECT * FROM Bookmarks WHERE UserId = {0} AND Favorited = 1 AND IsPublic = 1", id)
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Include(b => b.Tags)
                .ToListAsync();
        }

        public async virtual Task<List<Bookmark>> GetBookmarksByFollowersAsync(int id)
        {
            return await Bookmarks.FromSqlRaw("SELECT * FROM Bookmarks WHERE UserId IN (SELECT SubscriptionsId FROM UserUser WHERE FollowersId = {0}) AND IsPublic = 1 ORDER BY CreateDate DESC", id)
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Include(b => b.Tags)
                .ToListAsync();
        }

        public async virtual Task<Bookmark> GetBookmarkAsync(int id)
        {
            return await Bookmarks
                .Include(b => b.Resource)
                .Include(b => b.User)
                .Include(b => b.Tags)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public virtual void RemoveBookmark(Bookmark bookmark)
        {
            Bookmarks.Remove(bookmark);
        }

        public virtual void AddBookmark(Bookmark bookmark)
        {
            Bookmarks.Add(bookmark);
        }

        #endregion

        #region Resources

        public async virtual Task<List<Resource>> GetResourcesAsync()
        {
            return await Resources
                .AsNoTracking()
                .ToListAsync();
        }

        public async virtual Task<Resource> GetResourceAsync(int id)
        {
            return await Resources.FindAsync(id);
        }

        public async virtual Task<Resource> GetResourceByLocationAsync(string location)
        {
            return await Resources.FirstOrDefaultAsync(r => r.Location == location);
        }

        public virtual void RemoveResource(Resource resource)
        {
            Resources.Remove(resource);
        }

        public virtual EntityEntry<Resource> AddResource(Resource resource)
        {
            return Resources.Add(resource);
        }

        #endregion

        #region Users

        public async virtual Task<List<User>> GetUsersAsync()
        {
            return await Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async virtual Task<List<User>> GetUsersExportAsync()
        {
            return await Users
                .Include(u => u.Roles)
                .Include(u => u.Subscriptions)
                .AsNoTracking()
                .ToListAsync();
        }

        public async virtual Task<User> GetUserAsync(int id)
        {
            return await Users
                .Include(u => u.Roles)
                .Include(u => u.Subscriptions)
                .Include(u => u.Followers)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async virtual Task<User> GetUserByUsernameAsync(string username)
        {
            return await Users
                .Include(u => u.Roles)
                .Include(u => u.Subscriptions)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async virtual Task<User> GetUserByGithubId(string id)
        {
            return await Users
            .Include(u => u.Subscriptions)
            .Include(u => u.Followers)
            .FirstOrDefaultAsync(u => u.GithubId == id);
        }

        public virtual void RemoveUser(User user)
        {
            Users.Remove(user);
        }

        public virtual EntityEntry<User> AddUser(User user)
        {
            return Users.Add(user);
        }

        #endregion

        #region Roles

        public async virtual Task<List<Role>> GetRolesAsync()
        {
            return await Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public async virtual Task<Role> GetRoleAsync(int id)
        {
            return await Roles.FindAsync(id);
        }

        public async virtual Task<Role> GetRoleByNameAsync(string name)
        {
            return await Roles
                .FirstOrDefaultAsync(r => r.Name == name);
        }

        public virtual void RemoveRole(Role role)
        {
            Roles.Remove(role);
        }

        public virtual void AddRole(Role role)
        {
            Roles.Add(role);
        }

        #endregion

        #region Notifications

        public async virtual Task<List<Notification>> GetNotificationsByUser(int id)
        {
            return await Notifications.FromSqlRaw("SELECT * FROM Notifications WHERE UserId IN (SELECT SubscriptionsId FROM UserUser WHERE FollowersId = {0}) ORDER BY CreateDate", id)
                .ToListAsync();
        }

        public virtual void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }

        #endregion
    }
}
