using HrRework.Domain.Base;
using HrRework.Domain.Interviews;
using System.Collections.Generic;

namespace HrRework.Domain.Candidates
{
    public class Candidate : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Interview> Interviews { get; set; }
    }
}
