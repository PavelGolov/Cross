using System.Collections.Generic;

namespace Cross.Model
{
    public class Status : DbModel
    {
        public string Name { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<Action> ActionSets { get; set; }

        public virtual ICollection<ActionStatus> ActionStatuses { get; set; }
    }
}
