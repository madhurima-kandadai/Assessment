namespace CSharpAssignment.Services.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<CrimeDetail> CrimeDetails { get; set; }
        public virtual DbSet<CrimeType> CrimeTypes { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<MD_Criminals> MD_Criminals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany(e => e.MD_Criminals)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);
        }
    }
}
