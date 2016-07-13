// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrimeTypeModel.cs" company="Alliance Global Services">
//   Copyright 2016
// </copyright>
// <summary>
//   The CrimeTypeModel.
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
    /// Class  CrimeTypeModel
    /// </summary>
    public class CrimeTypeModel
    {
        /// <summary>
        /// Gets or sets the crime type identifier.
        /// </summary>
        /// <value>
        /// The crime type identifier.
        /// </value>
        public int CrimeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the crime type.
        /// </summary>
        /// <value>
        /// The name of the crime type.
        /// </value>
        public string CrimeTypeName { get; set; }
    }
}