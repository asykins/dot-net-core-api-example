using HrRework.Application.Interviews.Queries;
using HrRework.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HrRework.Api.Interviews.V2.Controllers
{
    [ApiController]
    [ApiVersion(Constants.ApiVersions.TwoDotZero)]
    [Route(Constants.RouteTemplates.ApiInterview)]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewQuery interviewQuery;

        public InterviewController(IInterviewQuery interviewQuery)
        {
            this.interviewQuery = interviewQuery
                ?? throw new ArgumentNullException(nameof(interviewQuery));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var interviews = interviewQuery.Find();

                if (!interviews?.Any() ?? true)
                {
                    return NotFound();
                }

                return Ok(new { data = interviews });
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
        public IActionResult GetById(int id)
        {
            try
            {
                var interview = interviewQuery.FindById(id);

                if(interview == null)
                {
                    return NotFound();
                }

                return Ok(new { data = interview });
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
