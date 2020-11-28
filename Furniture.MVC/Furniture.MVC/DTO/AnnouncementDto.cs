using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Furniture.MVC.DTO
{
    public class AnnouncementDto
    {
        public string AnnounceContent { get; set; }
        [Required(ErrorMessage = "يجب ادخال عنوان المقال")]
        public string AnnounceHeader { get; set; }
        public string AnnouncePhotoPath { get; set; }
        [Required(ErrorMessage = "يجب ادخال تاريخ نتهاء الاعلان")]
        public DateTime? ExpireDate { get; set; }
    }
}