using Microsoft.EntityFrameworkCore;

namespace SevenLab
{
    public partial class GameDBContext : DbContext
    {
        public GameDBContext(DbContextOptions<GameDBContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Developers> Developers { get; set; }

        public DbSet<Games> Games { get; set; }
    }
}
