using HrRework.Application.Base;
using System;

namespace HrRework.Application.Interviews.Models
{
    public class InterviewQueryModel : QueryModel
    {
        public DateTime ScheduledDate { get; set; }
        public string Comment { get; set; }
        public int Note { get; set; }

        public int CandidateId { get; set; }
        public int InterviewerId { get; set; }

        public string CandidateName { get; set; }
        public string InterviewerName { get; set; }
    }
}
