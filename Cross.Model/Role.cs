using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Cross.Model
{
    public class Role: IdentityRole<int>
    {
        public virtual ICollection<Action> Actions { get; set; }
    }
}
