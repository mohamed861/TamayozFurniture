using Furniture.MVC.Data;
using Furniture.MVC.DTO;
using Furniture.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture.MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ITrackRepo _repo;

        public AdminController(ITrackRepo repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var services = await _repo.GetServiceReport();
            var adminDto = new AdminDto
            {
                ServiceReports = services,
                Announcement = new AnnouncementDto()
            };
            return View(adminDto);
        }


        public async Task<IActionResult> Add(AnnouncementDto announcementDto)
        {

            var files = HttpContext.Request.Form.Files;
            foreach (var img in files)
            {
                var destination = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img");
                if (img != null && img.Length > 0)
                {
                    var timeNow = DateTime.UtcNow.Ticks;
                    var path = timeNow + img.FileName;
                    var fullpath = @Path.Combine(destination, path);
                    using (var stream = new FileStream(fullpath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        await img.CopyToAsync(stream);
                    }

                    var announce = new Announcement
                    {
                        AnnounceContent = announcementDto.AnnounceContent,
                        AnnounceDate = DateTime.Now,
                        AnnounceExpireDate = announcementDto.ExpireDate,
                        AnnounceHeader = announcementDto.AnnounceHeader,
                        AnnouncePhotoPath = path,

                    };
                    await _repo.AddAnnounce(announce);
                    await _repo.SaveChanges();
                }
            }
            return RedirectToAction("thanks", "Home");
        }
    }
}
