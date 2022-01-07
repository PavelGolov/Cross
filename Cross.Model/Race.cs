using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cross.Model
{
    public class Race : CancellationDbModel
    {
        public DateTime DateTime { get; set; }

        [ForeignKey("RaceStatus")]
        public int RaceStatusId { get; set; }

        [ForeignKey("Discipline")]
        public int DisciplineId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        [ForeignKey("Track")]
        public int TrackId { get; set; }

        public virtual RaceStatus RaceStatus { get; set; }

        public virtual Discipline Discipline { get; set; }

        public virtual Event Event { get; set; }

        public virtual Track Track { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
