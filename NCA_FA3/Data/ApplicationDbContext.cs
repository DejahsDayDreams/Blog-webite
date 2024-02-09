using Microsoft.EntityFrameworkCore;
using NCA_FA3.Models;
using System.Configuration;

namespace NCA_FA3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }


        // DbSet properties for your entities 
        public DbSet<Student> BlogPosts { get; set; }

        
    }
}
