using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture.MVC.Models
{
    public partial class Ksacity
    {
        public Ksacity()
        {
            RequestServiceCityFroms = new HashSet<RequestService>();
            RequestServiceCityTos = new HashSet<RequestService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RequestService> RequestServiceCityFroms { get; set; }
        public virtual ICollection<RequestService> RequestServiceCityTos { get; set; }
    }
}
