using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furniture.MVC.Models;
namespace Furniture.MVC.Data
{
    public interface ITrackRepo
    {
        Task<List<Ksacity>> GetKsacities();
        Task<List<Service>> GetServices();
        Task<RequestService> AddOrder(RequestService order);
        Task<bool> SaveChanges();
    }
}
