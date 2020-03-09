using HrRework.Domain.Candidates;
using HrRework.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrRework.Infrastructure.Candidates
{
    public class CandidateEntityConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable(Constants.Database.CandidateTableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);

            builder.HasMany(x => x.Interviews)
                   .WithOne(x => x.Candidate);
        }
    }
}
