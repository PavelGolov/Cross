using System.Collections.Generic;

namespace Cross.Model
{
    public class RaceType : DbModel
    {
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
