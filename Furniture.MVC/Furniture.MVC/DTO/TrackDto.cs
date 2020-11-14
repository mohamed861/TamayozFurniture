using Furniture.MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture.MVC.DTO
{
    public class TrackDto
    {
        [Required(ErrorMessage = "يجب ادخال المدينة ")]

        public int? fromCity { get; set; }
        [Required(ErrorMessage = "يجب ادخال المدينة ")]
        public int? toCity { get; set; }

        public List<Ksacity> Ksacities { get; set; }

    }
}
