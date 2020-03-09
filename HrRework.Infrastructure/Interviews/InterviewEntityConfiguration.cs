using HrRework.Domain.Interviews;
using HrRework.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrRework.Infrastructure.Interviews
{
    public class InterviewEntityConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.ToTable(Constants.Database.InterviewTableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.InterviewType);
            builder.Property(x => x.Comment);
            builder.Property(x => x.Note);
            builder.Property(x => x.ScheduledDate);

            builder.HasOne(x => x.Interviewer)
                   .WithMany(x => x.Interviews);

            builder.HasOne(x => x.Candidate)
                   .WithMany(x => x.Interviews);
        }
    }
}
