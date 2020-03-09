using HrRework.Application.Interviewers.Models;
using HrRework.Domain.Interviewers;
using System.Collections.Generic;

namespace HrRework.Application.Interviewers.Queries
{
    public interface IInterviewerQuery
    {
        IEnumerable<InterviewerQueryModel> Find();
        InterviewerQueryModel FindById(int id);
        IEnumerable<InterviewerQueryModel> Map(IEnumerable<Interviewer> interviewers);
        InterviewerQueryModel Map(Interviewer interviewer);
    }
}
