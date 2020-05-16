using HrRework.Application.Base;
using HrRework.Application.Interviews.Models;
using System;
using System.Collections.Generic;

namespace HrRework.Application.Candidates.Models
{
    public class CandidateQueryModel : QueryModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public IEnumerable<InterviewQueryModel> Interviews { get; set; }
    }
}
