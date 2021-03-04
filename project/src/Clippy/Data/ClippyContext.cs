using Clippy.Entities;
using Clippy.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Clippy.Data {
    public class ClippyContext : DbContext
    {
        public ClippyContext(DbContextOptions<ClippyContext> options)
            : base(options)
        {
        }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddResourceEntity();
            modelBuilder.AddUserEntity();
            modelBuilder.AddSeedData();
        }

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

        public virtual void AddResource(Resource resource)
        {
            Resources.Add(resource);
        }

        #endregion

        #region Users

        public async virtual Task<List<User>> GetUsersAsync()
        {
            return await Users
                .AsNoTracking()
                .ToListAsync();
        }

        public async virtual Task<User> GetUserAsync(int id)
        {
            return await Users.FindAsync(id);
        }

        public async virtual Task<User> GetUserByUsernameAsync(string username)
        {
            return await Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public virtual void RemoveUser(User user)
        {
            Users.Remove(user);
        }

        public virtual void AddUser(User user)
        {
            Users.Add(user);
        }

        #endregion
    }
}
