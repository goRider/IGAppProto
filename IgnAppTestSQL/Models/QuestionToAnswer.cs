using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgnAppTestSQL.Models
{
    public class QuestionToAnswer
    {
        public int QuestionAnswerId { get; set; }
        public string FirstQuestion { get; set; }
        public string SecondQuestion { get; set; }
        public string ThirdQuestion { get; set; }
        public string FourthQuestion { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string FourthAnswer { get; set; }

        #region Navigation

        public IgniteUserApplication IgniteUserApplication { get; set; }
        public int? FkIgniteUserApplicationId { get; set; }

        #endregion
    }
}
