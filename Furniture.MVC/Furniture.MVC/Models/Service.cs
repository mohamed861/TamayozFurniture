using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture.MVC.Models
{
    public partial class Service
    {
        public Service()
        {
            RequestServices = new HashSet<RequestService>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }

        public virtual ICollection<RequestService> RequestServices { get; set; }
    }
}
