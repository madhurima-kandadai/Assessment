namespace CSharpAssignment.Services.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CrimeDetail
    {
        public int Id { get; set; }

        public int CriminalId { get; set; }

        public int? CrimeTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CrimeDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ConvictedOn { get; set; }

        public int? Duration { get; set; }

        public virtual CrimeType CrimeType { get; set; }
    }
}
