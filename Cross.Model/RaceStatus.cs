using System.Collections.Generic;

namespace Cross.Model
{
    public class RaceStatus : DbModel
    {
        public string Name { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
