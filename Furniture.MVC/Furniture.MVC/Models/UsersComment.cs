using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture.MVC.Models
{
    public partial class UsersComment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public DateTime? CommentDate { get; set; }
        public string UserEmail { get; set; }
        public int? Rating { get; set; }
        public string UserFullName { get; set; }
        public int? RequestServiceId { get; set; }

        public virtual RequestService RequestService { get; set; }
    }
}
