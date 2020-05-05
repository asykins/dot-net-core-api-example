using GraphQL.Types;
using HrRework.Application.Candidates.GraphQL;
using HrRework.Application.Interfaces;
using HrRework.Application.Interview.GraphQL;
using HrRework.Application.Interviewers.GraphQL;
using HrRework.Shared;
using Microsoft.EntityFrameworkCore;

namespace HrRework.Application.Interviews.GraphQL
{
    public class InterviewGraphType : ObjectGraphType<Domain.Interviews.Interview>
    {
        public InterviewGraphType(IInterviewRepository interviewRepository)
        {
            Field(x => x.Comment);
            Field(x => x.Id);
            Field(x => x.Note);
            Field(x => x.ScheduledDate);

            Field<InterviewEnumType>(Constants.GraphQl.InterviewTypeField);

            Field<CandidateGraphType>
                (Constants.GraphQl.CandidateField,
                 resolve: context =>
                 {
                     return interviewRepository.FirstOrDefault(x => x.Id == context.Source.Id,
                                                               x => x.Include(x => x.Candidate))
                                               .Candidate;
                 });

            Field<InterviewerGraphType>
                (Constants.GraphQl.InterviewerField,
                 resolve: context =>
                 {
                     return interviewRepository.FirstOrDefault(x => x.Id == context.Source.Id,
                                                               x => x.Include(x => x.Interviewer))
                                               .Interviewer;
                 });
        }
    }
}
