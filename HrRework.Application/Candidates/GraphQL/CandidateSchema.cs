using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrRework.Application.Candidates.GraphQL
{
    public class CandidateSchema : Schema
    {
        public CandidateSchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<CandidateGraphQuery>();
        }
    }
}
