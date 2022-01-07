using System.ComponentModel.DataAnnotations.Schema;

namespace Cross.Model
{
    public class ActionStatus : DbModel
    {
        [ForeignKey("Action")]
        public int ActionId { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public virtual Action Action { get; set; }

        public virtual Status Status { get; set; }
    }
}
