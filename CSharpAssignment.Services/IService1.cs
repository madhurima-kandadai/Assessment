using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using CSharpAssignment.Services.Models;

namespace CSharpAssignment.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    /// <summary>
    ///     Interface IService1
    /// </summary>
    [ServiceContract]
    public interface IService1
    {
        /// <summary>
        /// Gets the criminal search details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [OperationContract]
        int GetCriminalSearchDetails(CriminalModel model);
        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<LocationModel> GetLocations();
        /// <summary>
        /// Gets the crime types.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CrimeTypeModel> GetCrimeTypes();
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [OperationContract]
        string GetData(int value);

        /// <summary>
        /// Gets the data using data contract.
        /// </summary>
        /// <param name="composite">The composite.</param>
        /// <returns></returns>
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CompositeType
    {
        /// <summary>
        /// The bool value
        /// </summary>
        bool boolValue = true;
        /// <summary>
        /// The string value
        /// </summary>
        string stringValue = "Hello ";

        /// <summary>
        /// Gets or sets a value indicating whether [bool value].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [bool value]; otherwise, <c>false</c>.
        /// </value>
        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        /// <summary>
        /// Gets or sets the string value.
        /// </summary>
        /// <value>
        /// The string value.
        /// </value>
        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
