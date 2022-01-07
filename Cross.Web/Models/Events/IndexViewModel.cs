using System;
using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Events
{
    public class IndexViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Место проведения")]
        public string Venue { get; set; }

        [Display(Name = "Вид")]
        public string RaceType { get; set; }

        public bool IsCancelled { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
    }
}
