using GraphQL.Types;
using HrRework.Application.Candidates.GraphQL;
using HrRework.Application.Interfaces;
using HrRework.Application.Interviewers.GraphQL;
using HrRework.Application.Interviews.GraphQL;
using HrRework.Shared;

namespace HrRework.Application.Base
{
    public class HrReworkQuery : ObjectGraphType
    {
        public HrReworkQuery(ICandidateRepository candidateRepository,
                             IInterviewerRepository interviewerRepository,
                             IInterviewRepository interviewRepository)
        {
            Field<ListGraphType<CandidateGraphType>>(
                Constants.GraphQl.CandidatesField,
                resolve: context => candidateRepository.Find());

            Field<ListGraphType<InterviewGraphType>>
                (Constants.GraphQl.InterviewsField,
                 resolve: context => interviewRepository.Find());

            Field<ListGraphType<InterviewerGraphType>>
                (Constants.GraphQl.InterviewersField,
                 resolve: context => interviewerRepository.Find());

            Field<CandidateGraphType>(
                Constants.GraphQl.CandidateField,
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return candidateRepository.FirstOrDefault(x => x.Id == id);
                });

            Field<InterviewerGraphType>(
                Constants.GraphQl.InterviewerField,
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return interviewerRepository.FirstOrDefault(x => x.Id == id);
                });

            Field<InterviewGraphType>(
                Constants.GraphQl.InterviewField,
                arguments: new QueryArguments(new QueryArgument<IdGraphType>
                {
                    Name = "id"
                }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return interviewRepository.FirstOrDefault(x => x.Id == id);
                });
        }
    }
}
