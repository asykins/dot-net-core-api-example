using HrRework.Application.Interviews.Models;
using HrRework.Domain.Interviews;
using System.Collections.Generic;

namespace HrRework.Application.Interviews.Queries
{
    public interface IInterviewQuery
    {
        public IEnumerable<InterviewQueryModel> Find();
        public InterviewQueryModel FindById(int id);
        public IEnumerable<InterviewQueryModel> FindByCandidateId(int id);
        public IEnumerable<InterviewQueryModel> FindByInterviewerId(int id);
        public IEnumerable<InterviewQueryModel> Map(IEnumerable<Interview> interviews);
        public InterviewQueryModel Map(Interview interview);
    }
}
