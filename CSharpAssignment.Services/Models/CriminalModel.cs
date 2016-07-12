// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CriminalModel.cs" company="Alliance Global Services">
//   Copyright 2016
// </copyright>
// <summary>
//   The CriminalModel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CSharpAssignment.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class  CriminalModel
    /// </summary>
    public class CriminalModel
    {
        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public int? Age { get; set; }
        /// <summary>
        /// Gets or sets the convicted on.
        /// </summary>
        /// <value>
        /// The convicted on.
        /// </value>
        public DateTime? ConvictedOn { get; set; }
        /// <summary>
        /// Gets or sets the crime.
        /// </summary>
        /// <value>
        /// The crime.
        /// </value>
        public string Crime { get; set; }

        public int CrimeTypeId { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }
        /// <summary>
        /// Gets or sets the height in CMS.
        /// </summary>
        /// <value>
        /// The height in CMS.
        /// </value>
        public int? HeightInCms { get; set; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        public string Nationality { get; set; }
        /// <summary>
        /// Gets or sets the weight in pounds.
        /// </summary>
        /// <value>
        /// The weight in pounds.
        /// </value>
        public int? WeightInPounds { get; set; }
        /// <summary>
        /// Gets or sets the minimum height.
        /// </summary>
        /// <value>
        /// The minimum height.
        /// </value>
        public int? MinHeight { get; set; }

        /// <summary>
        /// Gets or sets the maximum height.
        /// </summary>
        /// <value>
        /// The maximum height.
        /// </value>
        public int? MaxHeight { get; set; }

        /// <summary>
        /// Gets or sets the minimum weight.
        /// </summary>
        /// <value>
        /// The minimum weight.
        /// </value>
        public int? MinWeight { get; set; }
        /// <summary>
        /// Gets or sets the maximum weight.
        /// </summary>
        /// <value>
        /// The maximum weight.
        /// </value>
        public int? MaxWeight { get; set; }
        /// <summary>
        /// Gets or sets the age range.
        /// </summary>
        /// <value>
        /// The age range.
        /// </value>
        public string AgeRange { get; set; }
    }
}