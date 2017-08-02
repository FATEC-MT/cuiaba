using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TokenManager.Entities;

namespace TokenManager.Services
{
    public class Request
    {
        public readonly HttpClient _httpclient;

        public Request(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        public async Task<Token> RequisitarToken()
        {
            var urlGenerateToken = new Uri("");
            var password = "";

            _httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpcontent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"client_id", ""},
                {"client_secret", ""},
                {"grant_type", ""}
            });

            var resultadoContent = await _httpclient.PostAsync(urlGenerateToken, httpcontent);
            return JsonConvert.DeserializeObject<Token>(await resultadoContent.Content.ReadAsStringAsync());
        }
    }
}