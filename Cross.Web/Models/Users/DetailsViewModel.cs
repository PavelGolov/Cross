using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Users
{
    public class DetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        public List<Cross.Web.Models.Cars.DetailsViewModel> Cars { get; set; }

        [Display(Name = "Роли пользователя")]
        public List<string> UserRoles { get; set; }
    }
}
