using GraphQL.Types;
using HrRework.Application.Interfaces;
using HrRework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrRework.Application.Interviewers.GraphQL
{
    public class InterviewerGraphQuery : ObjectGraphType
    {
        public InterviewerGraphQuery(IInterviewerRepository interviewerRepository)
        {
            Field<ListGraphType<InterviewerGraphType>>
                (Constants.GraphQl.InterviewersField,
                 resolve: context => interviewerRepository.Find());
        }
    }
}
