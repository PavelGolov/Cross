using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Home
{
    public class IndexViewModel
    {
        public int raceId { get; set; }

        [Display(Name = "Место проведения")]
        public string Venue { get; set; }

        [Display(Name = "Вид")]
        public string RaceType { get; set; }

        public bool IsCancelled { get; set; }

        [Display(Name = "Дата и время")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Статус ")]
        public string RaceStatus { get; set; }

        [Display(Name = "Класс")]
        public string Discipline { get; set; }

        [Display(Name = "Трасса")]
        public string Track { get; set; }

        [Display(Name = "")]
        public Dictionary<int, string> Actions { get; set; }
    }
}
