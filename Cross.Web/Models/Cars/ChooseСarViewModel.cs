using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Cars
{
    public class BasicCarInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Номер автомобиля")]
        public string LicensePlate { get; set; }
    }

    public class ChooseСarViewModel
    {
        public int RaceId { get; set; }

        public int ActionId { get; set; }

        public List<BasicCarInfoViewModel> Cars { get; set; }
    }
}
