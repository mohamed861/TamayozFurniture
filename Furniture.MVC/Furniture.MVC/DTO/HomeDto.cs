using System.Collections.Generic;

namespace Furniture.MVC.DTO
{
    public class HomeDto
    {
        public int Id { get; set; }

        public List<AnnouncementDto> Announcements { get; set; }
        public List<ServiceDto> Services { get; set; }
        public List<UserCommentsDto> UserComments { get; set; }

    }
}