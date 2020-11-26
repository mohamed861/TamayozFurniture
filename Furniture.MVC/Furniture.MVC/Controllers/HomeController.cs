using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Furniture.MVC.Data;
using Furniture.MVC.DTO;
using Microsoft.AspNetCore.Authorization;
using Furniture.MVC.HelperClasses;

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
            var userComments = await _repo.GetComments();
            var homeDto = new HomeDto
            {
                Services = services.Select(a => new ServiceDto
                {
                    Id = a.Id,
                    ServiceName = a.ServiceName,
                    ServiceDescription = a.ServiceDescription,
                    ServicePhotoPath = a.ServicePhotoPath,
                    ServiceSubHeader = a.ServiceSubHeader
                }).ToList(),
                Announcements = announces.Select(a => new AnnouncementDto
                {
                    AnnounceContent = a.AnnounceContent,
                    AnnounceHeader = a.AnnounceHeader,
                    AnnouncePhotoPath = a.AnnouncePhotoPath
                }).ToList(),
                UserComments = userComments.Select(a => new UserCommentsDto
                {
                    CommentText = a.CommentText,
                    UserFullName = a.UserFullName,
                    Rating = a.Rating

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

        [NoDirectAccessAttribute]
        public IActionResult Error()
        {
            return View();
        }
        [NoDirectAccessAttribute]
        public IActionResult Thanks()
        {
            ViewBag.serviceId = TempData["ServiceId"];
            return View();
        }

    }
}
