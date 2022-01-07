using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Requests
{
    public class IndexViewModel
    {
        public int RequestId { get; set; }

        [Display(Name = "Место проведения")]
        public string Venue { get; set; }

        [Display(Name = "Вид")]
        public string RaceType { get; set; }

        [Display(Name = "Дата и время")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Статус ")]
        public string RaceStatus { get; set; }

        [Display(Name = "Класс")]
        public string Discipline { get; set; }

        [Display(Name = "Трасса")]
        public string Track { get; set; }

        [Display(Name = "Электронная почта пользователя")]
        public string User { get; set; }

        [Display(Name = "Номер автомобиля")]
        public string LicensePlate { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime Created { get; set; }

        [Display(Name = "Дата модификации")]
        public DateTime Modifed { get; set; }

        [Display(Name = "")]
        public Dictionary<int, string> Actions { get; set; }

        [Display(Name = "Комментарий подтверждающего")]
        public string Comment { get; set; }
    }
}
