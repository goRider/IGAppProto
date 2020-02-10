using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgnAppTestSQL.Data;

namespace IgnAppTestSQL.Models
{
    public class BusinessUnit
    {
        public int BUID { get; set; }
        public string BusinessUnitName { get; set; }
        public ICollection<IgniteUser> IgniteUsers { get; set; }
    }
}
