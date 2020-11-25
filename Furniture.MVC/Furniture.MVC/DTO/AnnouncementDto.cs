using Microsoft.AspNetCore.Http;
using System;

namespace Furniture.MVC.DTO
{
    public class AnnouncementDto
    {
        public string AnnounceContent { get; set; }
        public string AnnounceHeader { get; set; }
        public string AnnouncePhotoPath { get; set; }
        public IFormFile Img { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}