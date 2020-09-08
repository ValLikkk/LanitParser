using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LanitParser.Parser
{
    class HtmlLoader
    {
        private readonly HttpClient client;

        private readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = settings.Url;
        }

        public async Task<string> GetSource()
        {
            var response = await client.GetAsync(url);
            string source = null;        
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
