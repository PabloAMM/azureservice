using azureservice.Common.Response;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace azureservice.Common.Models
{
    public class Service
    {

        public async Task<ServiceResponse> ServicioTRM(TrmRequest request)
        {
            var httpClient = new HttpClient();
            var user = "cliente";
            var password = "Cliente2021**";

            var authToken = Encoding.ASCII.GetBytes($"{user}:{password}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8);

            var result = await httpClient.PostAsync("http://159.65.255.33:9092/Exchange/", httpContent);


            var Trm = await result.Content.ReadAsStringAsync();

            ServiceResponse json = System.Text.Json.JsonSerializer.Deserialize<ServiceResponse>(Trm);

            return json;


        }

    }
}
