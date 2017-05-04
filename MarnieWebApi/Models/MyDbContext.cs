namespace MarnieWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext")
        {
        }

        public virtual DbSet<Date> Dates { get; set; }
        public virtual DbSet<Jorney> Jorneys { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonDate> PersonDates { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<Stop> Stops { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Date>()
                .HasMany(e => e.PersonDates)
                .WithRequired(e => e.Date)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Jorneys)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonDates)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Stops)
                .WithRequired(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stop>()
                .Property(e => e.ArrivalTime)
                .HasPrecision(0);

            modelBuilder.Entity<Stop>()
                .Property(e => e.DepartureTime)
                .HasPrecision(0);
        }
    }
}
