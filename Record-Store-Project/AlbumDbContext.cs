using Record_Store_Project.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Record_Store_Project
{
    public class AlbumDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public AlbumDbContext(DbContextOptions<AlbumDbContext> options) : base(options) { }
    }
}
