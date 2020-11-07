using studentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace studentApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Student> students { get; set; }
    }
}