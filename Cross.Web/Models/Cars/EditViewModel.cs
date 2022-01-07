using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Cars
{
    public class EditViewModel
    {
        public int? Id { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Номер автомобиля")]
        public string LicensePlate { get; set; }

        [Display(Name = "Вид заезда")]
        public int RaceTypeId { get; set; }

        [Display(Name = "Класс автомобиля")]
        public int DisciplineId { get; set; }
    }
}
