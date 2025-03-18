using RPG_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace RPG_Project.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Personagem> Personagens { get; set; }
    }
}