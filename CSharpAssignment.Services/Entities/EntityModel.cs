namespace CSharpAssignment.Services.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    ///     Class Entity Model
    /// </summary>
    public partial class EntityModel : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityModel"/> class.
        /// </summary>
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        /// <summary>
        /// Gets or sets the crime details.
        /// </summary>
        /// <value>
        /// The crime details.
        /// </value>
        public virtual DbSet<CrimeDetail> CrimeDetails { get; set; }
        /// <summary>
        /// Gets or sets the crime types.
        /// </summary>
        /// <value>
        /// The crime types.
        /// </value>
        public virtual DbSet<CrimeType> CrimeTypes { get; set; }
        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>
        /// The locations.
        /// </value>
        public virtual DbSet<Location> Locations { get; set; }
        /// <summary>
        /// Gets or sets the m d_ criminals.
        /// </summary>
        /// <value>
        /// The m d_ criminals.
        /// </value>
        public virtual DbSet<MD_Criminals> MD_Criminals { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasMany(e => e.MD_Criminals)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);
        }
    }
}
