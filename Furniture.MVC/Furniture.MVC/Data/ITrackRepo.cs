﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furniture.MVC.DTO;
using Furniture.MVC.Models;
namespace Furniture.MVC.Data
{
    public interface ITrackRepo
    {
        Task<List<Ksacity>> GetKsacities();
        Task<List<Service>> GetServices();
        Task<List<UsersComment>> GetComments(int id = 0);
        Task<int> GetSerCommentsCount(int id = 0);
        Task<List<UsersComment>> UpdateComments(int serviceId, int pageNumber);
        Task<UsersComment> AddtComment(UsersComment comment);
        Task<RequestService> AddOrder(RequestService order);
        Task<double?> GetAverageRate(int id = 0);
        Task<int> GetCommentCount(int id = 0);
        Task<List<Announcement>> GetAnnounces();
        Task<bool> SaveChanges();
        Task<User> Login(string userName, string password);
        Task<Announcement> AddAnnounce(Announcement announce);

        Task<List<ServiceReportDto>> GetServiceReport();
    }
}
