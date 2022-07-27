using Microsoft.AspNet.SignalR.Hosting;
using Newtonsoft.Json;
using NPoco.fastJSON;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using UmbarcowithCrm.Models;
using Umbraco.Web.Mvc;

namespace UmbarcowithCrm.Controller
{
    public class ContactSurfaceController : SurfaceController
    {
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Contact/";

        public ActionResult RenderForm()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "_Contact.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactModel model)

        {
            
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44388/contact/");
                        ContactModel obj = new ContactModel() { FirstName = model.FirstName, LastName = model.LastName, EmailAddress = model.EmailAddress, JobTittle = model.JobTittle, PhoneNumber = model.PhoneNumber, Message = model.Message };
                        var json = new JavaScriptSerializer().Serialize(obj);
                        var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                        var response = client.PostAsync("https://prod-188.westeurope.logic.azure.com:443/workflows/c966a251cd5d4088bfaa55ecd5719f34/triggers/manual/paths/invoke?api-version=2016-06-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Ur4PVADUlK0oWWlo8uMjPPfxEscXBmFEsNonZaQEGX0"
                        , content).Result;

                        if (response.IsSuccessStatusCode)
                        {
                        TempData["ContactSuccess"] = true;
                    }
                        else
                            Console.Write("Error");
                    }

                    return RedirectToCurrentUmbracoPage();
                }
                return CurrentUmbracoPage();
            
        }

        private void SendEmail(ContactModel model)
        {
            //MailMessage message = new MailMessage(model.EmailAddress, "website@installumbraco.web.local");
            //message.Subject = string.Format("Enquiry from {0} {1} - {2}", model.FirstName, model.LastName, model.EmailAddress);
            //message.Body = model.Message;
            //SmtpClient client = new SmtpClient("127.0.0.1", 25);
            //client.Send(message);
        }
    }
}