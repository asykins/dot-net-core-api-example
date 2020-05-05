using GraphQL.Types;
using HrRework.Application.Interfaces;
using HrRework.Application.Interviews.GraphQL;
using HrRework.Domain.Interviewers;
using HrRework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrRework.Application.Interviewers.GraphQL
{
    public class InterviewerGraphType : ObjectGraphType<Interviewer>
    {
        public InterviewerGraphType(IInterviewRepository interviewRepository)
        {
            Field(x => x.FirstName);
            Field(x => x.Id);
            Field(x => x.LastName);

            Field<ListGraphType<InterviewGraphType>>
                (Constants.GraphQl.InterviewsField,
                 resolve: context => interviewRepository.Find(x => x.Interviewer.Id == context.Source.Id));
        }
    }
}
