using System.Collections.Generic;

namespace Cross.Model
{
    public class Venue : DbModel
    {
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
