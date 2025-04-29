using DentElora.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;
using System.IO.Pipelines;
using System.Reflection;

namespace DentElora.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            
            
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "admin",
                password = "xyz123456"
            });
        }
    }
}
