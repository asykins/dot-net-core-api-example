using HrRework.Application.Base;
using HrRework.Application.Interviews.Models;
using System.Collections.Generic;

namespace HrRework.Application.Interviewers.Models
{
    public class InterviewerQueryModel : QueryModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<InterviewQueryModel> Interviews { get; set; }
    }
}
