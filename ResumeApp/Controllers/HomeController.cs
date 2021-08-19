using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ResumeApp.Data;
using ResumeApp.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ResumeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IResumeRepository _repository;

        public HomeController(IConfiguration config, IResumeRepository repository)
        {
            _config= config;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Message(MessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            var message = new Message { FirstName = model.FirstName, Email = model.Email,
                                        Comment = model.Comment, LastName = model.LastName,
                                        Subject = model.Subject                                        
                                       };
            await _repository.AddMessageAsync(message);
            ViewBag.Success = true;
            return View("Index");
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
