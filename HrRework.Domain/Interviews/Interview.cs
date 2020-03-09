using HrRework.Domain.Base;
using HrRework.Domain.Candidates;
using HrRework.Domain.Interviewers;
using System;

namespace HrRework.Domain.Interviews
{
    public class Interview : Entity
    {
        public DateTime ScheduledDate { get; set; }
        public string Comment { get; set; }
        public int Note { get; set; }

        public Interviewer Interviewer { get; set; }
        public Candidate Candidate { get; set; }
        public InterviewType InterviewType { get; set; }
    }
}
