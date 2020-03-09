using HrRework.Application.Interviewers.Queries;
using HrRework.Application.Interviews.Queries;
using HrRework.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HrRework.Api.Interviewers.V2.Controllers
{
    [ApiController]
    [ApiVersion(Constants.ApiVersions.TwoDotZero)]
    [Route(Constants.RouteTemplates.ApiInterviewer)]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewQuery interviewQuery;
        private readonly IInterviewerQuery interviewerQuery;

        public InterviewerController(IInterviewQuery interviewQuery,
                                     IInterviewerQuery interviewerQuery)
        {
            this.interviewQuery = interviewQuery 
                ?? throw new ArgumentNullException(nameof(interviewQuery));
            this.interviewerQuery = interviewerQuery 
                ?? throw new ArgumentNullException(nameof(interviewerQuery));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var interviewers = interviewerQuery.Find();

                if(!interviewers?.Any() ?? true)
                {
                    return NotFound();
                }

                return Ok(new { data = interviewers });
            }
            catch (Exception exception)
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
                var interviewer = interviewerQuery.FindById(id);

                if(interviewer == null)
                {
                    return NotFound();
                }

                return Ok(new { data = interviewer });
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
        public IActionResult GetInterviewerInterviews(int id)
        {
            try
            {
                var interviewerInterviews = interviewQuery.FindByInterviewerId(id);

                if(!interviewerInterviews?.Any() ?? true)
                {
                    return NotFound();
                }

                return Ok(new { data = interviewerInterviews });
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
