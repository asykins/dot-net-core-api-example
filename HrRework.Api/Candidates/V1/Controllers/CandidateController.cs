using HrRework.Application.Candidates.Queries;
using HrRework.Application.Interviews.Queries;
using HrRework.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HrRework.Api.Candidates.V1.Controllers
{
    [ApiController]
    [ApiVersion(Constants.ApiVersions.OneDotZero)]
    [Route(Constants.RouteTemplates.ApiCandidate)]
    
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateQuery candidateQuery;
        private readonly IInterviewQuery interviewQuery;

        public CandidateController(ICandidateQuery candidateQuery,
                                   IInterviewQuery interviewQuery)
        {
            this.candidateQuery = candidateQuery 
                ?? throw new ArgumentNullException(nameof(candidateQuery));
            this.interviewQuery = interviewQuery 
                ?? throw new ArgumentNullException(nameof(interviewQuery));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var candidates = candidateQuery.Find();

                if (!candidates?.Any() ?? true)
                {
                    return NotFound();
                }

                return Ok(candidates);
            }
            catch(Exception exception)
            {
                return Problem(
                    detail: exception.Message,
                    statusCode: 500,
                    title: Constants.ErrorMessages.AnErrorOccured);
            }
        }

        [HttpGet(Constants.RouteTemplates.Id)]
        public IActionResult Get(int id)
        {
            try
            {
                var candidate = candidateQuery.FindById(id);

                if(candidate == null)
                {
                    return NotFound();
                }

                return Ok(candidate);

            }
            catch (Exception exception)
            {
                return Problem(
                    detail: exception.Message,
                    statusCode: 500,
                    title: Constants.ErrorMessages.AnErrorOccured);
            }
        }

        [HttpGet(Constants.RouteTemplates.IdInterview)]
        public IActionResult GetCandidateInterviews(int id)
        {
            try
            {
                var candidateInterviews = interviewQuery.FindByCandidateId(id);

                if(!candidateInterviews?.Any() ?? true)
                {
                    return NotFound();
                }

                return Ok(candidateInterviews);
            }
            catch (Exception exception)
            {
                return Problem(
                    detail: exception.Message,
                    statusCode: 500,
                    title: Constants.ErrorMessages.AnErrorOccured);
            }
        }
    }
}
