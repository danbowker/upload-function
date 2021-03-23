using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace dan.upload
{
    public static class Upload
    {
        [Function("Upload")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Upload");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var message = new System.IO.StreamReader(req.Body).ReadToEnd().Trim('"');

            logger.LogInformation($"Called with {message}");

            response.WriteString("Welcome to Azure " + message);

            return response;
        }
    }
}
