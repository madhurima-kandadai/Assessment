using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using CSharpAssignment.Services.Entities;
using CSharpAssignment.Services.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CSharpAssignment.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    /// <summary>
    /// Class Service 1
    /// </summary>
    public class Service1 : IService1
    {
        /// <summary>
        /// The host
        /// </summary>
        private string host = ConfigurationManager.AppSettings["Host"].ToString();
        /// <summary>
        /// The port
        /// </summary>
        private string port = ConfigurationManager.AppSettings["Port"].ToString();
        /// <summary>
        /// The sender email identifier
        /// </summary>
        private string senderEmailId = ConfigurationManager.AppSettings["MailId"].ToString();
        /// <summary>
        /// The password
        /// </summary>
        private string password = ConfigurationManager.AppSettings["Password"].ToString();
        /// <summary>
        /// The model context
        /// </summary>
        private EntityModel modelContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="Service1" /> class.
        /// </summary>
        public Service1()
        {
            modelContext = new EntityModel();
        }
        /// <summary>
        /// Gets the crime types.
        /// </summary>
        /// <returns></returns>
        public List<CrimeTypeModel> GetCrimeTypes()
        {
            var list = modelContext.CrimeTypes.AsQueryable().ToList();
            var crimeTypeList = (from crimeType in list
                                 select new CrimeTypeModel
                                 {
                                     CrimeTypeId = crimeType.Id,
                                     CrimeTypeName = crimeType.Type
                                 }).ToList();
            return crimeTypeList;
        }

        /// <summary>
        /// Gets the locations.
        /// </summary>
        /// <returns></returns>
        public List<LocationModel> GetLocations()
        {
            var list = modelContext.Locations.AsQueryable().ToList();
            var locationList = (from loc in list
                                select new LocationModel
                                {
                                    LocationId = loc.Id,
                                    LocationName = loc.Location1
                                }).ToList();
            return locationList;
        }

        /// <summary>
        /// Gets the criminal search details.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public int GetCriminalSearchDetails(CriminalModel model)
        {
            var criminals = modelContext.MD_Criminals.AsQueryable();
            var crimeTypes = modelContext.CrimeTypes.AsQueryable();
            var crimeDetails = modelContext.CrimeDetails.AsQueryable();
            var locations = modelContext.Locations.AsQueryable();
            var result = (from criminal in criminals
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
                              LocationId = location.Id,
                              Gender = criminal.Gender,
                              Nationality = criminal.Nationality,
                              WeightInPounds = criminal.Weight,
                              CrimeTypeId = crimeType.Id,
                              InPrison = criminal.InPrison == true ? "Yes" : "No"
                          });
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
                result = result.Where(x => x.Nationality.ToLower().Contains(model.Nationality.ToLower()));
            }

            if (!string.IsNullOrEmpty(model.AgeRange))
            {
                var age = model.AgeRange.Split('-').ToList();
                int minAge = Convert.ToInt32(age[0]);
                int maxAge = Convert.ToInt32(age[1]);
                result = result.Where(x => x.Age >= minAge && x.Age <= maxAge);
            }

            if (model.MinHeight != 0 && model.MinHeight != null)
            {
                result = result.Where(x => x.HeightInCms >= model.MinHeight);
            }

            if (model.MaxHeight != 0 && model.MaxHeight != null)
            {
                result = result.Where(x => x.HeightInCms <= model.MaxHeight);
            }

            if (model.MinWeight != 0 && model.MinWeight != null)
            {
                result = result.Where(x => x.WeightInPounds >= model.MinWeight);
            }

            if (model.MaxWeight != 0 && model.MaxWeight != null)
            {
                result = result.Where(x => x.WeightInPounds <= model.MaxWeight);
            }

            if (model.LocationId != 0)
            {
                result = result.Where(x => x.LocationId == model.LocationId);
            }

            if (model.CrimeTypeId != 0)
            {
                result = result.Where(x => x.CrimeTypeId == model.CrimeTypeId);
            }
            if (result.Any())
            {
                var list = result.ToList();
                var thread = new Thread(delegate () { SendEmailWithPdf(list, model.EmailId); });
                thread.Start();
            }
            return result.Count();
        }

        /// <summary>
        /// Sends the email with PDF.
        /// </summary>
        /// <param name="criminalModelList">The criminal model list.</param>
        /// <param name="receiverId">The receiver identifier.</param>
        private void SendEmailWithPdf(List<CriminalModel> criminalModelList, string receiverId)
        {
            var list = new List<List<CriminalModel>>();

            for (int i = 0; i < criminalModelList.Count; i += 10)
            {
                list.Add(criminalModelList.GetRange(i, Math.Min(10, criminalModelList.Count - i)));
            }
            foreach (var listObject in list)
            {
                MailMessage mailMessage = new MailMessage(senderEmailId, receiverId);
                foreach (var item in listObject)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Paragraph("Criminal Details of " + item.Name + "\n"));
                        pdfDoc.Add(new Paragraph("Gender : " + item.Gender + "\n"));
                        pdfDoc.Add(new Paragraph("Age : " + item.Age + "\n"));
                        pdfDoc.Add(new Paragraph("Convicted On : " + item.ConvictedOn + "\n"));
                        pdfDoc.Add(new Paragraph("Crime : " + item.Crime + "\n"));
                        pdfDoc.Add(new Paragraph("Height (In Cms) : " + item.HeightInCms + "\n"));
                        pdfDoc.Add(new Paragraph("Weight (In Pounds) : " + item.WeightInPounds + "\n"));
                        pdfDoc.Add(new Paragraph("Nationality : " + item.Nationality + "\n"));
                        pdfDoc.Add(new Paragraph("In Prison : " + item.InPrison + "\n"));
                        pdfDoc.AddCreationDate();
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                        mailMessage.Attachments.Add(new Attachment(new MemoryStream(bytes), item.Name + ".pdf"));
                    }
                }
                mailMessage.Subject = "Criminal Details";
                mailMessage.Body = "Hi," + Environment.NewLine + " Attached are the details of Criminals depending on your search";
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = host;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = senderEmailId;
                NetworkCred.Password = password;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = Convert.ToInt32(port);
                smtp.Send(mailMessage);
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        /// <summary>
        /// Gets the data using data contract.
        /// </summary>
        /// <param name="composite">The composite.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">composite</exception>
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
