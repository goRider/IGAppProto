using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgnAppTestSQL.Data
{
    public class IgniteRole : IdentityRole<int>
    {
        public IgniteRole()
        {

        }

        public IgniteRole(string rolename, string newrole)
        {

        }

        public IgniteRole(string roleName) : base(roleName)
        {
        }
    }
}
