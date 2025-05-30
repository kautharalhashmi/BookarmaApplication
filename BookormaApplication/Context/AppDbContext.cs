using BookormaApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookormaApplication.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){ }


            public DbSet<Book> books {  get; set; }
    }
}
