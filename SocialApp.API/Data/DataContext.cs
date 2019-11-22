using Microsoft.EntityFrameworkCore;
using SocialApp.API.Models;

namespace SocialApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}