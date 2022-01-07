using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cross.Model
{
    public class Track : DbModel
    {
        public string Name { get; set; }

        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
