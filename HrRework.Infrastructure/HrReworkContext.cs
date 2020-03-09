using HrRework.Domain.Candidates;
using HrRework.Domain.Interviewers;
using HrRework.Domain.Interviews;
using HrRework.Infrastructure.Candidates;
using HrRework.Infrastructure.Interviewers;
using HrRework.Infrastructure.Interviews;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace HrRework.Infrastructure
{
    public class HrReworkContext : DbContext
    {
        public HrReworkContext([NotNull] DbContextOptions options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InterviewerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new InterviewEntityConfiguration());
        }

        DbSet<Candidate> Candidates { get; set; }
        DbSet<Interviewer> Interviewers { get; set; }
        DbSet<Interview> Interviews { get; set; }
    }
}
