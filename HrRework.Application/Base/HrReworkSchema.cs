using GraphQL;
using GraphQL.Types;

namespace HrRework.Application.Base
{
    public class HrReworkSchema : Schema
    {
        public HrReworkSchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<HrReworkQuery>();
            Mutation = dependencyResolver.Resolve<HrReworkMutation>();
        }
    }
}
