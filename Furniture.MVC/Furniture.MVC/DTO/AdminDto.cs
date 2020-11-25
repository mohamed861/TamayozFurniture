using System.Collections.Generic;

namespace Furniture.MVC.DTO
{
    public class AdminDto
    {
        public List<ServiceReportDto> ServiceReports { get; set; }
        public AnnouncementDto Announcement { get; set; }

    }
}
