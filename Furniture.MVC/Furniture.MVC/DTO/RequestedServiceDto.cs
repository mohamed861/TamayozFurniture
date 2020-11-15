using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Furniture.MVC.DTO
{
    public class RequestedServiceDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال المدينة ")]

        public int? fromCity { get; set; }
        [Required(ErrorMessage = "يجب ادخال المدينة ")]
        public int? toCity { get; set; }

        public List<cityDto> Ksacities { get; set; }


        [Required(ErrorMessage = "يجب ادخال الاسم")]
        public string Name { get; set; }


        [Required(ErrorMessage = "يجب ادخال العنوان")]
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "الايميل غير صحيح")]
        [Required(ErrorMessage = "يجب ادخال الايميل")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "هاتف غير صالح")]
        [Required(ErrorMessage = "يجب ادخال الهاتف")]
        public string Phone { get; set; }
    }
    public class HomeDto
    {
        public List<AnnouncementDto> Announcements { get; set; }
        public List<ServiceDto> Services { get; set; }

    }
    public class AnnouncementDto
    {
        public string AnnounceContent { get; set; }
        public string AnnounceHeader { get; set; }
    }
    public class ServiceDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
    }
}