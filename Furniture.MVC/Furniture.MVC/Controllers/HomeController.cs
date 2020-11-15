using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Furniture.MVC.Data;
using Furniture.MVC.DTO;

namespace Furniture.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITrackRepo _repo;

        public HomeController(ITrackRepo repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _repo.GetServices();
            var announces = await _repo.GetAnnounces();
            var homeDto = new HomeDto
            {
                Services = services.Select(a => new ServiceDto
                {
                    Id = a.Id,
                    ServiceName = a.ServiceName
                }).ToList(),
                Announcements = announces.Select(a => new AnnouncementDto
                {
                    AnnounceContent = a.AnnounceContent,
                    AnnounceHeader = a.AnnounceHeader
                }).ToList()
            };
            return View(homeDto);
        }

        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult Map()
        {
            return View();
        }


    }
}
