using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using iTopClientService.Model;
using iTopClientService.Options;

using Microsoft.Extensions.Options;
using iTopClientService.Contract.V1.Response;
using iTopClientService.Contract.V1.Requests;

namespace iTopClientService.Service
{
    internal class iTopService : IiTopService
    {
        private readonly iTopAPIOptions ItopAPIOptions;

        public iTopService(IOptions<iTopAPIOptions> settings)
        {
            ItopAPIOptions = settings.Value;
        }

        

        private static async Task<HttpResponseMessage> iTopAPIWorker(iTopAPIMessage Message)
        {
            
            HttpResponseMessage res = null;
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, Message.EndPoint))
            {
                string json = JsonConvert.SerializeObject(Message.Create);
                using (HttpContent stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Message.Credentials);
                    stringContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        res = response;
                    }
                }
            }
            return res;
        }




        public async Task<iTopCreateResponse> CreateInsidentAsync(iTopCreateRequest message)
        {
            
            iTopAPIMessage msg = new iTopAPIMessage();
            msg.EndPoint = ItopAPIOptions.Endpoint;
            var creds = new Credentials { Username = ItopAPIOptions.Username, Password = ItopAPIOptions.Password };
            msg.Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(creds.Username));
            msg.Create = message;
            //msg.Create.operation = message.operation;
            //msg.Create.fields.caller_id.first_name = "";
            //msg.Create.fields.caller_id.name = "";
            var response = await iTopAPIWorker(msg);
            return JsonConvert.DeserializeObject<iTopCreateResponse>(response.Content.ReadAsStringAsync().Result);
        }
    }
    
}