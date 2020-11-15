using System.Collections.Generic;

namespace Furniture.MVC.DTO
{
    public class HomeDto
    {
        public List<AnnouncementDto> Announcements { get; set; }
        public List<ServiceDto> Services { get; set; }

    }
}