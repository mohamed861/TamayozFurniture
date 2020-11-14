using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Furniture.MVC.Models;
using Furniture.MVC.Data;
using Furniture.MVC.DTO;

namespace Furniture.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITrackRepo _repo;

        public HomeController(ILogger<HomeController> logger, ITrackRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _repo.GetServices();
            HomeDto home = new HomeDto()
            {
                Services = services.Select(a => new ServiceDto
                {
                    Id = a.Id,
                    Name = a.ServiceName
                }).ToList()
            };
            return View(home);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Single()
        {
            return View();
        }
        public IActionResult Map()
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
