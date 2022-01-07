using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Cross.Model
{
    public class User: IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
