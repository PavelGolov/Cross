using System;
using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Races
{
    public class IndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Дата и время")]
        public DateTime DateTime { get; set; }

        public bool IsCancelled { get; set; }

        [Display(Name = "Вид")]
        public string RaceStatus { get; set; }

        [Display(Name = "Класс")]
        public string Discipline { get; set; }

        public int EventId { get; set; }

        [Display(Name = "Трасса")]
        public string Track { get; set; }
    }
}
