using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynchronicWorldClass.Models
{
    public class SynchronicWorldDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TypeEvent> TypeEvents { get; set; }
        public DbSet<StatusEvent> StatusEvents { get; set; }
        public DbSet<PersonEvent> PersonEvents { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<TypeContribution> TypeContributions { get; set; }

        public SynchronicWorldDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SynchronicWorldDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Event>().HasRequired(e => e.Person).WithMany().WillCascadeOnDelete(false);
        }
    }
}
