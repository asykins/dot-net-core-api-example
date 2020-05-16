using GraphQL.Types;

namespace HrRework.Application.Candidates.GraphQL
{
    public class CandidateInputType : InputObjectGraphType
    {
        public CandidateInputType()
        {
            Name = "candidateInput";
            Field<NonNullGraphType<IdGraphType>>("id");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("phone");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<DateTimeGraphType>>("brithDate");
        }
    }
}
