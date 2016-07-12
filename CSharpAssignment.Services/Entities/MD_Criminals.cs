namespace CSharpAssignment.Services.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MD_Criminals
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public int LocationId { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public bool? InPrison { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? Age { get; set; }

        public virtual Location Location { get; set; }
    }
}
