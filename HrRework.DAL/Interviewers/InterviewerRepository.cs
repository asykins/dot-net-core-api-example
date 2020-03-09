using HrRework.Application.Interfaces;
using HrRework.DAL.Base;
using HrRework.Domain.Interviewers;
using Microsoft.EntityFrameworkCore;

namespace HrRework.DAL.Interviewers
{
    public class InterviewerRepository : EntityFrameworkRepository<Interviewer>, IInterviewerRepository
    {
        public InterviewerRepository(DbContext HrReworkContext)
            : base(HrReworkContext)
        {
        }
    }
}
