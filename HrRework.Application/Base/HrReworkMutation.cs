using GraphQL.Types;
using HrRework.Application.Candidates.GraphQL;
using HrRework.Application.Interfaces;
using HrRework.Domain.Candidates;
using Microsoft.EntityFrameworkCore;

namespace HrRework.Application.Base
{
    public class HrReworkMutation : ObjectGraphType
    {
        public HrReworkMutation(ICandidateRepository candidateRepository)
        {
            FieldAsync<CandidateGraphType>(
                "updateCandidate",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CandidateInputType>> { Name = "candidateInput" }),
                resolve: async context =>
                {
                    var candidate = context.GetArgument<Candidate>("candidateInput");
                    return await context.TryAsyncResolve(
                        async c =>
                        {
                            await candidateRepository.SaveOrUpdate(candidate);
                            return candidateRepository
                                .FirstOrDefault(x => x.Id == candidate.Id,
                                                query => query.Include(x => x.Interviews)
                                                              .ThenInclude(x => x.Interviewer));
                        });
                }
            );
        }
    }
}
