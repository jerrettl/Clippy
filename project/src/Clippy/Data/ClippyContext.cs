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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddResourceEntity();
            modelBuilder.AddSeedData();
        }

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
    }
}
