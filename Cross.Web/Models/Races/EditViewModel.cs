using System;
using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Races
{
    public class EditViewModel
    {
        public int? Id { get; set; }

        [Display(Name = "Дата и время")]
        public DateTime DateTime { get; set; }

        public bool? IsCancelled { get; set; }

        [Display(Name = "Вид")]
        public int RaceStatusId { get; set; }

        [Display(Name = "Класс")]
        public int DisciplineId { get; set; }

        public int EventId { get; set; }
        [Display(Name = "Трасса")]

        public int TrackId { get; set; }
    }
}
