namespace CSharpAssignment.Services.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    ///     Class Location
    /// </summary>
    public partial class Location
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            MD_Criminals = new HashSet<MD_Criminals>();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the location1.
        /// </summary>
        /// <value>
        /// The location1.
        /// </value>
        [Column("Location")]
        [StringLength(50)]
        public string Location1 { get; set; }

        /// <summary>
        /// Gets or sets the m d_ criminals.
        /// </summary>
        /// <value>
        /// The m d_ criminals.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MD_Criminals> MD_Criminals { get; set; }
    }
}
