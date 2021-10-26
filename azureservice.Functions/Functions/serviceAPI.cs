using azureservice.Common.Models;
using azureservice.Common.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace azureservice.Functions.Functions
{
    public static class serviceAPI
    {
        [FunctionName(nameof(serviceAPI))]
        public static async Task<IActionResult> GetData(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "erp")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Querying data from ERP SAP.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);


            TrmRequest trm = JsonConvert.DeserializeObject<TrmRequest>(requestBody);

            if (string.IsNullOrEmpty(trm.connection.token))
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Messsage = "You must enter a token"
                });
            }

            if (string.IsNullOrEmpty(trm.connection.systemId))
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Messsage = "You must enter a system Id"
                });
            }

            if (string.IsNullOrEmpty(trm.exchange.dateValidity))
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Messsage = "You must enter a date"
                });
            }

            if (string.IsNullOrEmpty(trm.exchange._base))
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Messsage = "You must enter a base for currency"
                });
            }
            if (string.IsNullOrEmpty(trm.exchange.to.ToString()))
            {
                return new BadRequestObjectResult(new Response
                {
                    IsSuccess = false,
                    Messsage = "You must enter at least one exchange rate "
                });
            }

            Service service = new Service();

            var result = await service.ServicioTRM(trm);

            return new OkObjectResult(new Response
            {
                IsSuccess = true,
                Messsage = "Successful",
                Result = result
            });
        }
    }
}
