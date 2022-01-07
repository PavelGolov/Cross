using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.Model
{
    public class CancellationDbModel : DbModel
    {
        public bool IsCancelled { get; set; }
    }
}
