using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgnAppTestSQL.Models
{
    public class IgniteUserApplication
    {
        public int ApplicationId { get; set; }
        public string IgniteApplicationStatus { get; set; }
        public DateTime ApplicationCompletionDate { get; set; }
        public DateTime ManagerApplicationStatusChangeDate { get; set; }
        public DateTime UserApplicationCreationDate { get; set; }

        #region Application User Nav

        public int? FKApplicationStatusId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }

        public QuestionToAnswer QuestionToAnswer { get; set; }
        public int FkQuestionToAnswerId { get; set; }

        #endregion
    }
}
