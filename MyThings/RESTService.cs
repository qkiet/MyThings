using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;

namespace MyThings
{
    class RESTService
    {
        HttpClient Client;

        public RESTService()
        {
            Client = new HttpClient();
            Client.MaxResponseContentBufferSize = 256000;
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<string> Get(string url, CancellationToken ct)
        {
            HttpResponseMessage result = await Client.GetAsync(url, ct);
            string responseBody = await result.Content.ReadAsStringAsync();
            return responseBody;
        }
        public async Task<string> Get(string url)
        {
            HttpResponseMessage result = await Client.GetAsync(url);
            string responseBody = await result.Content.ReadAsStringAsync();
            return responseBody;
        }

    }
}
