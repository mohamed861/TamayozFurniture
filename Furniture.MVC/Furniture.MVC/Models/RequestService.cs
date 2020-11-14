using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture.MVC.Models
{
    public partial class RequestService
    {
        public RequestService()
        {
            UsersComments = new HashSet<UsersComment>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public bool? IsAdmin { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? ServiceId { get; set; }
        public string RequestText { get; set; }
        public int? CityFromId { get; set; }
        public int? CityToId { get; set; }
        public DateTime? RequestDate { get; set; }

        public virtual Ksacity CityFrom { get; set; }
        public virtual Ksacity CityTo { get; set; }
        public virtual Service Service { get; set; }
        public virtual ICollection<UsersComment> UsersComments { get; set; }
    }
}
