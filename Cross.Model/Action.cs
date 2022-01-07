using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cross.Model
{
    public class Action : DbModel
    {
        public string Name { get; set; }

        public string NameMUI { get; set; }

        public string ConfirmationMUI { get; set; }

        public string SuccessMUI { get; set; }

        [ForeignKey("SetStatus")]
        public int SetStatusId { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Status SetStatus { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<ActionStatus> ActionStatuses { get; set; }
    }
}
