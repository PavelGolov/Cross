using System.Collections.Generic;

namespace Cross.Model
{
    public class Discipline : DbModel
    {
        public string Name { get; set; }

        public virtual ICollection<Race> Races { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
