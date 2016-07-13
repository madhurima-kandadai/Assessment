namespace CSharpAssignment.Services.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    ///     Class MD_Criminals
    /// </summary>
    public partial class MD_Criminals
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        [StringLength(10)]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        [StringLength(50)]
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        public int? Weight { get; set; }

        /// <summary>
        /// Gets or sets the in prison.
        /// </summary>
        /// <value>
        /// The in prison.
        /// </value>
        public bool? InPrison { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public virtual Location Location { get; set; }
    }
}
