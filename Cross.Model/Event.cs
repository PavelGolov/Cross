using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cross.Model
{
    public class Event : CancellationDbModel
    {
        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        [ForeignKey("RaceType")]
        public int RaceTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }

        public virtual Venue Venue { get; set; }

        public virtual RaceType RaceType { get; set; }

        public virtual ICollection<Race> Races { get; set; }
    }
}
