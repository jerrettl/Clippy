using Microsoft.EntityFrameworkCore;

namespace Clippy.Api.Data
{
    public class ClippyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=clippy.db");
    }
}
