using HelloWorldCore6.Data;
using HelloWorldCore6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloWorldCore6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _myDbContext;

        public HomeController(ILogger<HomeController> logger, MyDbContext myDbContext)
        {
            _logger = logger;
            _myDbContext = myDbContext;
        }

        public IActionResult Index()
        {
            var model = new MessagesModel();
            model.MessageEntities.AddRange(_myDbContext.MessageEntities);
            return View(model);
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