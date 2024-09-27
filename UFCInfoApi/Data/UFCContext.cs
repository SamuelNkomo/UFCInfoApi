// Data/UFCContext.cs
using Microsoft.EntityFrameworkCore;
using UFCInfoApi.Models;

namespace UFCInfoApi.Data
{
    public class UFCContext : DbContext
    {
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Article> Articles { get; set; }

        public UFCContext(DbContextOptions<UFCContext> options) : base(options) { }
    }
}
