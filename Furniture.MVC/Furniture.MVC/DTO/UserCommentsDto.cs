using System;
using System.ComponentModel.DataAnnotations;

namespace Furniture.MVC.DTO
{
    public class UserCommentsDto
    {
        [Required(ErrorMessage = "يجب ادخال تعليق")]
        public string CommentText { get; set; }
        public DateTime? CommentDate { get; set; }
        [EmailAddress(ErrorMessage = "الايميل غير صحيح")]
        [Required(ErrorMessage = "يجب ادخال الايميل")]
        public string UserEmail { get; set; }
        public double? Rating { get; set; }
        [Required(ErrorMessage = "يجب ادخال الاسم")]
        [StringLength(20, ErrorMessage = "يجب ألا تزيد عدد الأحرف عن 20 حرفاً")]
        public string UserFullName { get; set; }
        public int? RequestServiceId { get; set; }
    }
}