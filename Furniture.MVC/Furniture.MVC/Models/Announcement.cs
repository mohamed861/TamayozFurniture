using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture.MVC.Models
{
    public partial class Announcement
    {
        public int Id { get; set; }
        public DateTime? AnnounceDate { get; set; }
        public DateTime? AnnounceExpireDate { get; set; }
        public string AnnounceContent { get; set; }
        public string AnnounceHeader { get; set; }
        public string AnnouncePhotoPath { get; set; }
    }
}
