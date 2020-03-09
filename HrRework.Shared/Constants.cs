using System;

namespace HrRework.Shared
{
    public static class Constants
    {
        public static class Database
        {
            public static readonly string ConnectionString = "HrReworkDataBase";
            public static readonly string InterviewerTableName = "Interviewers";
            public static readonly string InterviewTableName = "Interviews";
            public static readonly string CandidateTableName = "Candidates";
        }

        public static class ApiVersions
        {
            public const string OneDotZero = "1.0";
            public const string TwoDotZero = "2.0";
        }

        public static class RouteTemplates
        {
            public const string ApiCandidate = "api/candidate";
            public const string ApiInterview = "api/interview";
            public const string ApiInterviewer = "api/interviewer";

            public const string Id = "{id}";
            public const string IdInterviewer = "{id}/interviewer";
            public const string IdInterview = "{id}/interview";
        }

        public static class ErrorMessages
        {
            public static readonly string AnErrorOccured = "An error occured";
        }
    }
}
