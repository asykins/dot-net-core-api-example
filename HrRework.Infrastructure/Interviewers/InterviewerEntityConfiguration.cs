using HrRework.Domain.Interviewers;
using HrRework.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrRework.Infrastructure.Interviewers
{
    public class InterviewerEntityConfiguration : IEntityTypeConfiguration<Interviewer>
    {
        public void Configure(EntityTypeBuilder<Interviewer> builder)
        {
            builder.ToTable(Constants.Database.InterviewerTableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);

            builder.HasMany(x => x.Interviews)
                   .WithOne(x => x.Interviewer);
        }
    }
}
