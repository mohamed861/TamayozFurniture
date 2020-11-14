using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture.MVC.Models
{
    public partial class UsersOrder
    {
        public int Id { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? CityfromId { get; set; }
        public int? CityToId { get; set; }
        public string AssignedToUserId { get; set; }
    }
}
