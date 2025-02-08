using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.X509;
using PetAdoptionCenter.Domain.Domain_Models;
using PetAdoptionCenter.Service.Interface;
using System.Text;

namespace PetAdoptionCenter.Controllers
{
    public class AdoptionsController : Controller
    {
        private readonly IAdoptionService adoptionService;

        public AdoptionsController(IAdoptionService adoptionService)
        {
            this.adoptionService = adoptionService;
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

        }

        public IActionResult Index()
        {
            var all_adoption = adoptionService.GetAllAdoptions();
            return View(all_adoption);
        }


        public FileContentResult CreateInvoice(Guid Id)
        {
            HttpClient client = new HttpClient();
            string URL = "http://localhost:5065/api/Admin/GetDetails";
            var model = new
            {
                Id = Id 
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var data = response.Content.ReadAsAsync<Adoption>().Result;

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");
            var document = DocumentModel.Load(templatePath);
            document.Content.Replace("{{PetName}}", data.Pet.Name);
            document.Content.Replace("{{Breed}}", data.Pet.Breed);
            document.Content.Replace("{{CenterName}}", data.Pet.Center.Name);
            document.Content.Replace("{{CenterLocation}}", data.Center.Location);
            document.Content.Replace("{{FullName}}", data.User.FullName);



            var stream = new MemoryStream();
            document.Save(stream, new PdfSaveOptions());
            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportedInvoice.pdf");

        }


    }
}
