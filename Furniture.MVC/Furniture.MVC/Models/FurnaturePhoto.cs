using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture.MVC.Models
{
    public partial class FurnaturePhoto
    {
        public int Id { get; set; }
        public byte[] Photo { get; set; }
    }
}
