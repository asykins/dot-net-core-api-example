using HrRework.Application.Candidates.Models;
using HrRework.Domain.Candidates;
using System.Collections.Generic;

namespace HrRework.Application.Candidates.Queries
{
    public interface ICandidateQuery
    {
        IEnumerable<CandidateQueryModel> Find();
        CandidateQueryModel FindById(int id);
        IEnumerable<CandidateQueryModel> Map(IEnumerable<Candidate> candidates);
        CandidateQueryModel Map(Candidate candidate);
    }
}
