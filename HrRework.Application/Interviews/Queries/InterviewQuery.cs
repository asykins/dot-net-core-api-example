using HrRework.Application.Interfaces;
using HrRework.Application.Interviews.Models;
using HrRework.Domain.Interviews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HrRework.Application.Interviews.Queries
{
    public class InterviewQuery : IInterviewQuery
    {
        private readonly IInterviewRepository interviewRepository;

        public InterviewQuery(IInterviewRepository interviewRepository)
        {
            this.interviewRepository = interviewRepository
                ?? throw new ArgumentNullException(nameof(interviewRepository));
        }

        public IEnumerable<InterviewQueryModel> Find()
        {
            return Map(interviewRepository.Find(x => x.Include(x => x.Candidate),
                                                x => x.Include(x => x.Interviewer)));
        }

        public InterviewQueryModel FindById(int id)
        {
            return Map(interviewRepository.FirstOrDefault(x => x.Id == id,
                                                          x => x.Include(x => x.Candidate),
                                                          x => x.Include(x => x.Interviewer)));
        }

        public IEnumerable<InterviewQueryModel> FindByCandidateId(int id)
        {
            return Map(interviewRepository.Find(x => x.Candidate.Id == id,
                                                query => query.Include(x => x.Candidate),
                                                query => query.Include(x => x.Interviewer)));
        }

        public IEnumerable<InterviewQueryModel> FindByInterviewerId(int id)
        {
            return Map(interviewRepository.Find(x => x.Interviewer.Id == id,
                                                query => query.Include(x => x.Candidate),
                                                query => query.Include(x => x.Interviewer)));
        }

        public IEnumerable<InterviewQueryModel> Map(IEnumerable<Interview> interviews)
        {
            var interviewQueryModels = new List<InterviewQueryModel>();

            if(!interviews?.Any() ?? true)
            {
                return interviewQueryModels;
            }

            foreach (var interview in interviews)
            {
                interviewQueryModels.Add(Map(interview));
            }

            return interviewQueryModels;
        }

        public InterviewQueryModel Map(Interview interview)
        {
            if (interview == null)
                return null;

            return new InterviewQueryModel
            {
                CandidateId = interview.Candidate.Id,
                CandidateName = interview.Candidate.FirstName,
                Comment = interview.Comment,
                InterviewerId = interview.Interviewer.Id,
                InterviewerName = interview.Interviewer.FirstName,
                Note = interview.Note,
                ScheduledDate = interview.ScheduledDate
            };
        }
    }
}
