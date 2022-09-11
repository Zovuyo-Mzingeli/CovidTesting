using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Corona.Models;

namespace Corona.Controllers
{
    public class BaseController : Controller
    {

        public void Notify(string message, string title="Read The Message Below", 
                                    NotificationType notificationType=NotificationType.success)
        {
            var msg = new { 
                message = message, 
                title = title, 
                icon = notificationType.ToString(), 
                type = notificationType.ToString(),
                provider = GetProvider()
            };

            TempData["Message"] = JsonConvert.SerializeObject(msg);
        }

        private string GetProvider()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var value = configuration["NotificationProvider"];

            return value;
        }
    }
}