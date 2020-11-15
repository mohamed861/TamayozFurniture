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
    public class CommnetController : Controller
    {
        private readonly ITrackRepo _repo;

        public CommnetController(ITrackRepo repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var cities = await _repo.GetKsacities();
            var userComents = await _repo.GetComments();
            var averageRate = await _repo.GetAverageRate();
            var totalCount = await _repo.GetCommentCount();
            var reviewDto = new ReviewDto
            {
                ServiceDto = new RequestedServiceDto
                {
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
                TotalRates = totalCount
            };
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
            };
            await _repo.AddtComment(comment);
            await _repo.SaveChanges();
            return Redirect("Index");
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
            };
            await _repo.AddOrder(service);
            await _repo.SaveChanges();
            return Redirect("Index");
        }
    }
}
