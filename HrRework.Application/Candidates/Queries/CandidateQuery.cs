using HrRework.Application.Candidates.Models;
using HrRework.Application.Interfaces;
using HrRework.Application.Interviews.Queries;
using HrRework.Domain.Candidates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HrRework.Application.Candidates.Queries
{
    public class CandidateQuery : ICandidateQuery
    {
        private readonly ICandidateRepository candidateRepository;

        private readonly IInterviewQuery interviewQuery;

        public CandidateQuery(ICandidateRepository candidateRepository,
                              IInterviewQuery interviewQuery)
        {
            this.candidateRepository = candidateRepository 
                ?? throw new ArgumentNullException(nameof(candidateRepository));
            this.interviewQuery = interviewQuery
                ?? throw new ArgumentNullException(nameof(interviewQuery));
        }

        public IEnumerable<CandidateQueryModel> Find()
        {
            return Map(candidateRepository.Find(query => query.Include(x => x.Interviews).ThenInclude(x => x.Interviewer),
                                                query => query.Include(x => x.Interviews).ThenInclude(x => x.Candidate)));
        }

        public CandidateQueryModel FindById(int id)
        {
            return Map(candidateRepository.FirstOrDefault
                                    (x => x.Id == id,
                                     query => query.Include(x => x.Interviews).ThenInclude(x => x.Interviewer),
                                     query => query.Include(x => x.Interviews).ThenInclude(x => x.Candidate)));
        }

        public IEnumerable<CandidateQueryModel> Map(IEnumerable<Candidate> candidates)
        {
            var candidateQueryModels = new List<CandidateQueryModel>();

            if (!candidates?.Any() ?? true)
                return candidateQueryModels;

            foreach (var candidate in candidates)
            {
                candidateQueryModels.Add(Map(candidate));
            }

            return candidateQueryModels;
        }

        public CandidateQueryModel Map(Candidate candidate)
        {
            if (candidate == null)
                return null;

            return new CandidateQueryModel
            {
                Id = candidate.Id,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                Birthdate = candidate.Birthdate,
                Email = candidate.Email,
                Phone = candidate.Phone,
                Interviews = interviewQuery.Map(candidate.Interviews)
            };
        }

    }
}
