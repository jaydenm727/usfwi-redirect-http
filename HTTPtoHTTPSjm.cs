using System;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class HTTPtoHTTPSjm
    {
        [FunctionName("HTTPtoHTTPSjm")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string url = req.Query["url"];

            log.LogInformation($"URL Request: {url}");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(url);
            var content = await httpResponse.Content.ReadAsStringAsync();

            return new OkObjectResult(content);
        }
    }
}
