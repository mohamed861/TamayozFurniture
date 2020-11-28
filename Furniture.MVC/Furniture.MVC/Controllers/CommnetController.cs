using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furniture.MVC.Data;
using Furniture.MVC.DTO;
using Furniture.MVC.HelperClasses;
using Furniture.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Furniture.MVC.Controllers
{
    public class CommnetController : Controller
    {
        private readonly ITrackRepo _repo;

        public CommnetController(ITrackRepo repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index(int id)
        {

            if (id > 4 || id < 1)
                return RedirectToAction("Index", "Home");
            var cities = await _repo.GetKsacities();
            var userComents = await _repo.GetComments(id);
            var averageRate = await _repo.GetAverageRate(id);
            var totalCount = await _repo.GetCommentCount(id);
            var reviewDto = new ReviewDto
            {
                ServiceDto = new RequestedServiceDto
                {
                    ServiceId = id,
                    Ksacities = cities.Select(a => new cityDto
                    {
                        Id = a.Id,
                        Name = a.Name
                    }).ToList()
                },
                UserComments = userComents.Select(a => new UserCommentsDto
                {
                    CommentDate = a.CommentDate,
                    CommentText = a.CommentText,
                    Rating = a.Rating,
                    UserEmail = a.UserEmail,
                    UserFullName = a.UserFullName,
                    RequestServiceId = a.RequestServiceId
                }).ToList(),
                AvaregRate = (int)averageRate,
                AvaregRateFraction=Math.Round((decimal)averageRate,1),
                TotalRates = totalCount,
                CommentsDto = new UserCommentsDto
                {
                    RequestServiceId = id
                }
            };
            ViewBag.serviceId = id;
            TempData["ServiceId"] =$"{id}";
            ViewBag.serCommentsCount = await _repo.GetSerCommentsCount(id);
            return View(reviewDto);
        }
        public async Task<IActionResult> Comment(UserCommentsDto commentsDto)
        {
            var comment = new UsersComment
            {
                CommentDate = DateTime.Now,
                CommentText = commentsDto.CommentText,
                Rating = commentsDto.Rating,
                UserEmail = commentsDto.UserEmail,
                UserFullName = commentsDto.UserFullName,
                RequestServiceId = commentsDto.RequestServiceId
            };
            await _repo.AddtComment(comment);
            await _repo.SaveChanges();
            return RedirectToAction("thanks", "Home");
        }
        public async Task<IActionResult> Service(RequestedServiceDto serviceDto)
        {
            var service = new RequestService
            {
                CityFromId = serviceDto.fromCity,
                CityToId = serviceDto.toCity,
                Address = serviceDto.Address,
                Email = serviceDto.Email,
                FullName = serviceDto.Name,
                Phone = serviceDto.Phone,
                RequestDate = DateTime.Now,
                ServiceId = serviceDto.ServiceId
            };
            await _repo.AddOrder(service);
            await _repo.SaveChanges();
            return RedirectToAction("thanks", "Home");
        }

        [HttpGet]
        [NoDirectAccess]
        public async Task<IActionResult> UpdateComments(int id, string serviceId)
        {
            try
            {
                int serviceID = Convert.ToInt32(serviceId);
                var userComents = await _repo.UpdateComments(serviceID, id);
                return PartialView("_UpdateComments", userComents);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
