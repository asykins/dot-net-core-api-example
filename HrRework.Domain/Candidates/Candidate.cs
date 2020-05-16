using HrRework.Domain.Base;
using HrRework.Domain.Interviews;
using System;
using System.Collections.Generic;

namespace HrRework.Domain.Candidates
{
    public class Candidate : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }

        public IEnumerable<Interview> Interviews { get; set; }
    }
}
