namespace CSharpAssignment.Services.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    ///     Class Crime Type
    /// </summary>
    public partial class CrimeType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrimeType"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CrimeType()
        {
            CrimeDetails = new HashSet<CrimeDetail>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [StringLength(50)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the crime details.
        /// </summary>
        /// <value>
        /// The crime details.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CrimeDetail> CrimeDetails { get; set; }
    }
}
