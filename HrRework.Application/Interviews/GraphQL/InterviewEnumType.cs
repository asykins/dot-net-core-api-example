using GraphQL.Types;
using HrRework.Domain.Interviews;
using HrRework.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrRework.Application.Interview.GraphQL
{
    public class InterviewEnumType : EnumerationGraphType<InterviewType>
    {
        public InterviewEnumType()
        {
            Name = Constants.GraphQl.InterviewTypeField;            
        }
    }
}
