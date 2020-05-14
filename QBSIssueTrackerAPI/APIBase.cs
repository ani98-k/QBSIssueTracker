using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace QBSIssueTrackerAPI
{
    public class APIBase
    {
        private HttpClientHandler _hndlr = new HttpClientHandler();
        protected HttpClient _httpClient;
        protected string _baseUrl = "https://localhost:44341/api/";
        public APIBase()
        {
            _hndlr.UseDefaultCredentials = true;
            _httpClient = new HttpClient(_hndlr);
        }

        public Exception GetException(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.NotFound:
                    return new NotFoundException();

                case System.Net.HttpStatusCode.BadRequest:
                    return new BadRequestException();

                default:
                    return new UnknownResponseCodeException();
            }
        }
    }
    class NotFoundException: Exception
    {

    }
    class BadRequestException:Exception
    {

    }
    class UnknownResponseCodeException : Exception
    {

    }
}
