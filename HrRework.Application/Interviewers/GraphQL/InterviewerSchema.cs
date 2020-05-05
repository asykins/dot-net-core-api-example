using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrRework.Application.Interviewers.GraphQL
{
    public class InterviewerSchema : Schema
    {
        public InterviewerSchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<InterviewerGraphQuery>();
        }
    }
}
