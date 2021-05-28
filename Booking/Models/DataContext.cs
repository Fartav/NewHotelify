using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
//using Rubik_SDK;

namespace Booking.Models
{
    public class DataContext : DbContext
    {

        //--Old code
        //public DataContext() : base(WebConfigurationManager.ConnectionStrings["RubikCMSEntities"].ConnectionString) { }

        //--New code by Reza.Barza (to make use from main encrypted CS)
        //static string connectionString = ConnectionEncryption.Decrypt(GlobalDef.ConnectionString);
        //public DataContext() : base(connectionString) { }

        //--New code by Reza.Barza @201908261001 (to make use from main encrypted CS)
        //public DataContext() : base(GlobalDef.ConnectionStringDesecure) { }

        // Temporary hardcode connection string
        // TODO: Pass the connection string securly
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    @"Server=localhost;Database=booking;Trusted_Connection=True;",
            //    x => x.UseNetTopologySuite());
            optionsBuilder.UseSqlServer(
                @"Server=db;Database=AppDbContext;User=sa;Password=<YourStrong@Passw0rd>;",
                x => x.UseNetTopologySuite());
        }

        //-- Commented by Reza.Barza @201908171205PM (To handle possible errors in future)
        // Initialize with connectino string
        public DataContext()
        {
            
        }

        // TODO: Set connection string through DataContet parameter

        // Comented by Sharif @201910301400
        // Temporary disable extra configurations to migrate to dotnet core
        // Make sure database naming is convinient
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}

        public DbSet<Host> Hosts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ClosedDates> ClosedDates { get; set; }
        public DbSet<ReservedDates> ReservedDates { get; set; }
        public DbSet<AvailableDates> AvailableDates { get; set; }

        public DbSet<MultiMedia> MultiMedia { get; set; }
        public DbSet<MultiMediaType> MultiMediaTypes { get; set; }
        public DbSet<MultiMediaUsage> MultiMediaUsages { get; set; }

        public DbSet<Residence> Residences { get; set; }
        public DbSet<ResidenceRoom> ResidenceRooms { get; set; }
        public DbSet<ResidenceType> ResidenceTypes { get; set; }

        public DbSet<Entities> Entities { get; set; }
        public DbSet<EntityType> EntityTypes { get; set; }
        
        public DbSet<HostExtension> HostExtensions { get; set; }
        public DbSet<EventExtension> EventExtensions { get; set; }


        public override int SaveChanges()
        {

            // Set date information
            var selectedEntityList = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseModel && e.State != EntityState.Unchanged);
            foreach (var e in selectedEntityList)
            {
                switch (e.State)
                {
                    case EntityState.Added:
                        ((BaseModel)e.Entity).CreateDate = DateTime.Now;
                        ((BaseModel)e.Entity).CreateDateTicks = DateTime.Now.Ticks;
                        break;
                    case EntityState.Modified:
                        ((BaseModel)e.Entity).ModifyDate = DateTime.Now;
                        ((BaseModel)e.Entity).ModifyDateTicks = DateTime.Now.Ticks;
                        break;
                    case EntityState.Deleted:
                        ((BaseModel)e.Entity).DeleteDate = DateTime.Now;
                        ((BaseModel)e.Entity).DeleteDateTicks = DateTime.Now.Ticks;
                        break;
                }
            }
            // Override hard delete with soft delete
            foreach (var e in selectedEntityList)
            {
                if (e.State == EntityState.Deleted)
                {
                    ((BaseModel)e.Entity).IsDeleted = true;
                    e.State = EntityState.Modified;
                }
            }
            return base.SaveChanges();
        }
    }
}
