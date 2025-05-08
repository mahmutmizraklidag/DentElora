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
        public DbSet<TreatmentPhoto> TreatmentPhotos { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<HomeInfo> HomeInfos { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
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
        public DbSet<DentElora.Entities.Service> Service { get; set; } = default!;
    }
}
