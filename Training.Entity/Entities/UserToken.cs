using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Entity.Entities
{
    public class UserToken : IdentityUserToken<int>
    {
        public DateTime ExpireDate { get; set; }
    }
}
