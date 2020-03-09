using HrRework.Application.Interfaces;
using HrRework.Application.Interviewers.Models;
using HrRework.Application.Interviews.Queries;
using HrRework.Domain.Interviewers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HrRework.Application.Interviewers.Queries
{
    public class InterviewerQuery : IInterviewerQuery
    {
        private readonly IInterviewerRepository interviewerRepository;

        private readonly IInterviewQuery interviewQuery;

        public InterviewerQuery(IInterviewerRepository interviewerRepository,
                                IInterviewQuery interviewQuery)
        {
            this.interviewerRepository = interviewerRepository 
                ?? throw new ArgumentNullException(nameof(interviewerRepository));
            this.interviewQuery = interviewQuery 
                ?? throw new ArgumentNullException(nameof(interviewQuery));
        }
            
        public IEnumerable<InterviewerQueryModel> Find()
        {
            return Map(interviewerRepository.Find(query => query.Include(x => x.Interviews).ThenInclude(x => x.Interviewer),
                                                  query => query.Include(x => x.Interviews).ThenInclude(x => x.Candidate)));
                                        
        }

        public InterviewerQueryModel FindById(int id)
        {
            return Map(interviewerRepository.FirstOrDefault
                                    (x => x.Id == id,
                                     query => query.Include(x => x.Interviews).ThenInclude(x => x.Interviewer),
                                     query => query.Include(x => x.Interviews).ThenInclude(x => x.Candidate)));
        }

        public IEnumerable<InterviewerQueryModel> Map(IEnumerable<Interviewer> interviewers)
        {
            var interviewerQueryModels = new List<InterviewerQueryModel>();

            if (!interviewers?.Any() ?? true)
                return interviewerQueryModels;

            foreach(var interviewer in interviewers)
            {
                interviewerQueryModels.Add(Map(interviewer));
            }
            
            return interviewerQueryModels;
        }

        public InterviewerQueryModel Map(Interviewer interviewer)
        {
            if (interviewer == null)
                return null;

            return new InterviewerQueryModel
            {
                Id = interviewer.Id,
                FirstName = interviewer.FirstName,
                LastName = interviewer.LastName,
                Interviews = interviewQuery.Map(interviewer.Interviews)
            };
        }
    }
}
