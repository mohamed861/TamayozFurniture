using Furniture.MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture.MVC.Data
{
    public class TrackRepo : ITrackRepo
    {
        private readonly DataContext _context;

        public TrackRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Ksacity>> GetKsacities()
        {
            return await _context.Ksacities.ToListAsync();
        }

        public async Task<RequestService> AddOrder(RequestService order)
        {
            await _context.RequestServices.AddAsync(order);
            return order;
        }
        public async Task<bool> SaveChanges()
        {

            if ((await _context.SaveChangesAsync() > 0))
                return true;
            return false;

        }

        public async Task<List<Service>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<List<UsersComment>> GetComments()
        {
            var comments = await _context.UsersComments.ToListAsync();
            return comments;
        }

        public async Task<UsersComment> AddtComment(UsersComment comment)
        {
            await _context.AddAsync(comment);
            return comment;
        }

        public async Task<double?> GetAverageRate()
        {
            return await _context.UsersComments.AverageAsync(a => a.Rating);

        }

        public async Task<int> GetCommentCount()
        {
            return await _context.UsersComments.CountAsync();
        }

        public async Task<List<Announcement>> GetAnnounces()
        {
            return await _context.Announcements.Where(a => a.AnnounceExpireDate <= DateTime.Now).ToListAsync();
        }
    }
}
