using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cross.Model
{
    public class Request : DbModel
    {
        [ForeignKey("Race")]
        public int RaceId { get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modifed { get; set; }

        public string Comment { get; set; }

        public virtual Race Race { get; set; }

        public virtual Car Car{ get; set; }

        public virtual Status Status { get; set; }
    }
}
