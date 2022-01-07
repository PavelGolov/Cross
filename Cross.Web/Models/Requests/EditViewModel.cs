using System.ComponentModel.DataAnnotations;

namespace Cross.Web.Models.Requests
{
    public class EditViewModel
    {
        public int RequestId { get; set; }

        public int ActionId { get; set; }

        [Display(Name = "Комментарий подтверждающего")]
        public string Comment { get; set; }
    }
}
