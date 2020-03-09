using HrRework.Application.Interfaces;
using HrRework.DAL.Base;
using HrRework.Domain.Candidates;
using Microsoft.EntityFrameworkCore;

namespace HrRework.DAL.Candidates
{
    public class CandidateRepository : EntityFrameworkRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(DbContext HrReworkContext) 
            : base(HrReworkContext)
        {
        }
    }
}
