using GraphQL.Types;
using HrRework.Application.Interfaces;
using HrRework.Application.Interviews.GraphQL;
using HrRework.Domain.Candidates;
using HrRework.Shared;

namespace HrRework.Application.Candidates.GraphQL
{
    public class CandidateGraphType : ObjectGraphType<Candidate>
    {
        public CandidateGraphType(IInterviewRepository interviewRepository)
        {
            Field(x => x.FirstName);
            Field(x => x.Id);
            Field(x => x.LastName);

            Field<ListGraphType<InterviewGraphType>>
                (Constants.GraphQl.InterviewsField,
                resolve: context => interviewRepository.Find(x => x.Candidate.Id == context.Source.Id));
        }
    }
}
