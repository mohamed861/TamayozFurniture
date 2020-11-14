using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furniture.MVC.Data;
using Furniture.MVC.DTO;
using Furniture.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.MVC.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackRepo _repo;

        public TrackController(ITrackRepo repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var cities = await _repo.GetKsacities();
            var dto = new TrackDto();
            dto.Ksacities = cities;
            return View(dto);
        }
        [HttpPost]
        public async Task<ActionResult> Index(TrackDto trackDto)
        {
            if (ModelState.IsValid)
            {
                var service = new RequestService
                {
                    CityFromId = trackDto.fromCity,
                    CityToId = trackDto.toCity,
                    RequestDate = DateTime.Now,

                };
                await _repo.AddOrder(service);
                await _repo.SaveChanges();
                return Redirect("Home/index");

            }
            else
            {
                var cities = await _repo.GetKsacities();
                trackDto.Ksacities = cities;
                return View(trackDto);
            }

        }
    }
}
