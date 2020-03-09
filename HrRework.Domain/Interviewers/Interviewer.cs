using HrRework.Domain.Base;
using HrRework.Domain.Interviews;
using System.Collections.Generic;

namespace HrRework.Domain.Interviewers
{
    public class Interviewer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Interview> Interviews { get; set; }
    }
}
