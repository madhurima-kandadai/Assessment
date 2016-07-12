using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpAssignment.Models
{
    /// <summary>
    ///     Class Crimial Search View Model
    /// </summary>
    public class CriminalSearchViewModel
    {
        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public string Age { get; set; }
        /// <summary>
        /// Gets or sets the crime.
        /// </summary>
        /// <value>
        /// The crime.
        /// </value>
        public int Crime { get; set; }
        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }
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
    }
}