using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Users
{
    public class IndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Пользователь")]
        public string Name { get; set; }

        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Display(Name = "Роли пользователя")]
        public List<string> UserRoles { get; set; }

        [Display(Name = "Другие роли")]
        public List<string> OtherRoles { get; set; }
    }
}
