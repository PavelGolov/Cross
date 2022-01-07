using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cross.Model
{
    public abstract class DbModel
    {
        public int Id { get; set; }
    }
}
