using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Cars
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер автомобиля")]
        public string LicensePlate { get; set; }

        [Display(Name = "Вид заезда")]
        public string RaceType { get; set; }

        [Display(Name = "Класс автомобиля")]
        public string Discipline { get; set; }
    }
}
