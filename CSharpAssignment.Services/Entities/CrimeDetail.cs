namespace CSharpAssignment.Services.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    ///     Class Crime Detail
    /// </summary>
    public partial class CrimeDetail
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the criminal identifier.
        /// </summary>
        /// <value>
        /// The criminal identifier.
        /// </value>
        public int CriminalId { get; set; }

        /// <summary>
        /// Gets or sets the crime type identifier.
        /// </summary>
        /// <value>
        /// The crime type identifier.
        /// </value>
        public int? CrimeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the crime date.
        /// </summary>
        /// <value>
        /// The crime date.
        /// </value>
        [Column(TypeName = "date")]
        public DateTime? CrimeDate { get; set; }

        /// <summary>
        /// Gets or sets the convicted on.
        /// </summary>
        /// <value>
        /// The convicted on.
        /// </value>
        [Column(TypeName = "date")]
        public DateTime? ConvictedOn { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public int? Duration { get; set; }

        /// <summary>
        /// Gets or sets the type of the crime.
        /// </summary>
        /// <value>
        /// The type of the crime.
        /// </value>
        public virtual CrimeType CrimeType { get; set; }
    }
}
