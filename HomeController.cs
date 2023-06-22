using Microsoft.AspNetCore.Mvc;
using SimpleContact.Models;
using SimpleContact.Services.Implementation;
using System.Diagnostics;

namespace SimpleContact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Index(EmailDataModel data)
        {
            try
            {
                EmailService emailService = new EmailService();
                emailService.SendContactEmail(data.Name, data.Email, data.Message);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {   
                ViewBag.Error = ex.Message;
                return View(data);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}