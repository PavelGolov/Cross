using System;
using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Events
{
    public class EditViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Место проведения")]
        public int VenueId { get; set; }

        [Display(Name = "Вид")]
        public int RaceTypeId { get; set; }

        public bool? IsCancelled { get; set; }

        [Display(Name = "Дата начала")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [Display(Name = "Дата окончания")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
    }
}
