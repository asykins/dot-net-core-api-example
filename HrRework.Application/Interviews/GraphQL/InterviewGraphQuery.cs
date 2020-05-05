using GraphQL.Types;
using HrRework.Application.Interfaces;
using HrRework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrRework.Application.Interviews.GraphQL
{
    public class InterviewGraphQuery : ObjectGraphType
    {
        public InterviewGraphQuery(IInterviewRepository interviewRepository)
        {
            Field<ListGraphType<InterviewGraphType>>
                (Constants.GraphQl.InterviewsField,
                 resolve: context => interviewRepository.Find());
        }
    }
}
