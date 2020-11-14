using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture.MVC.Models
{
    public partial class UsersPhone
    {
        public string UserId { get; set; }
        public string Phone { get; set; }

        public virtual RequestService User { get; set; }
    }
}
