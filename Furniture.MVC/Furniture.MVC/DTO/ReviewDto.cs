using System.Collections.Generic;

namespace Furniture.MVC.DTO
{
    public class ReviewDto
    {
        public List<UserCommentsDto> UserComments { get; set; }
        public int AvaregRate { get; set; }
        public decimal AvaregRateFraction { get; set; }
        public int TotalRates { get; set; }
        public RequestedServiceDto ServiceDto { get; set; }
        public UserCommentsDto CommentsDto { get; set; }
    }
}