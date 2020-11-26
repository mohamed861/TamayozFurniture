using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture.MVC.DTO
{
    public class ServiceReportDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string FromCity { get; set; }
        public string Address { get; set; }
        public string ToCity { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
    }
}
