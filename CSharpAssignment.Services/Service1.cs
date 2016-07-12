using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CSharpAssignment.Services.Entities;
using CSharpAssignment.Services.Models;

namespace CSharpAssignment.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private EntityModel modelContext;
        public Service1()
        {
            modelContext = new EntityModel();
        }
        public List<CrimeTypeModel> GetCrimeTypes()
        {
            var list = modelContext.CrimeTypes.AsQueryable().ToList();
            var crimeTypeList = ( from crimeType in list
                                  select new CrimeTypeModel
                                  {
                                      CrimeTypeId = crimeType.Id,
                                      CrimeTypeName = crimeType.Type
                                  } ).ToList();
            return crimeTypeList;
        }

        public List<LocationModel> GetLocations()
        {
            var list = modelContext.Locations.AsQueryable().ToList();
            var locationList = ( from loc in list
                                 select new LocationModel
                                 {
                                     LocationId = loc.Id,
                                     LocationName = loc.Location1
                                 } ).ToList();
            return locationList;
        }

        public List<CriminalModel> GetCriminalSearchDetails(CriminalModel model)
        {
            var criminals = modelContext.MD_Criminals.AsQueryable();
            var crimeTypes = modelContext.CrimeTypes.AsQueryable();
            var crimeDetails = modelContext.CrimeDetails.AsQueryable();
            var locations = modelContext.Locations.AsQueryable();
            var result = ( from criminal in criminals
                           join crime in crimeDetails on criminal.Id equals crime.CriminalId
                           join crimeType in crimeTypes on crime.CrimeTypeId equals crimeType.Id
                           join location in locations on criminal.LocationId equals location.Id
                           select new CriminalModel
                           {
                               Name = criminal.Name,
                               Age = criminal.Age,
                               HeightInCms = criminal.Height,
                               ConvictedOn = crime.ConvictedOn,
                               Crime = crimeType.Type,
                               Location = location.Location1,
                               Gender = criminal.Gender,
                               Nationality = criminal.Nationality,
                               WeightInPounds = criminal.Weight,
                               CrimeTypeId = crimeType.Id
                           } );
            if (!string.IsNullOrEmpty(model.Name))
            {
                result = result.Where(x => x.Name.ToLower().Contains(model.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.Gender))
            {
                result = result.Where(x => x.Gender.ToLower().Contains(model.Gender.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.Nationality))
            {
                result = result.Where(x => x.Gender.ToLower().Contains(model.Gender.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.AgeRange))
            {
                var age = model.AgeRange.Split('-').Cast<int>().ToList();
                result = result.Where(x => x.Age >= age[0] && x.Age <= age[1]);
            }

            if (model.MinHeight != 0)
            {
                result = result.Where(x => x.HeightInCms >= model.MinHeight);
            }

            if (model.MaxHeight != 0)
            {
                result = result.Where(x => x.HeightInCms <= model.MaxHeight);
            }

            if (model.MinWeight != 0)
            {
                result = result.Where(x => x.WeightInPounds >= model.MinWeight);
            }

            if (model.MaxWeight != 0)
            {
                result = result.Where(x => x.WeightInPounds >= model.MaxWeight);
            }

            if (!string.IsNullOrEmpty(model.Location))
            {
                result = result.Where(x => x.Location == model.Location);
            }

            if (model.CrimeTypeId != 0)
            {
                result = result.Where(x => x.CrimeTypeId == model.CrimeTypeId);
            }

            return result.ToList();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
