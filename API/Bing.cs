using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SearchFight.Api
{
    internal class Bing: IDisposable
    {
        private HttpClient _BingHttpClient;

        internal Bing()
        {
            this._BingHttpClient = new HttpClient();
            this._BingHttpClient.DefaultRequestHeaders.Add("Bing-Search-ApiKey", Constants.BingSearchApiKey);
        }

        public void Dispose()
        {
            this._BingHttpClient.Dispose();
            this._BingHttpClient = null;
        }

        internal Entity.Bing.Search Search(string word)
        {
            Entity.Bing.Search _result = new Entity.Bing.Search();
            
            string _json = string.Format("{{\"query\":\"equals('{0}')\"}}", word);
            StringContent _stringContent = new StringContent(_json, Encoding.UTF8, "application/json");

            HttpResponseMessage _response = this._BingHttpClient.PostAsync(Constants.BingSearchUrl, _stringContent).Result;

            if (_response.IsSuccessStatusCode)
            {
                string _stringResult = _response.Content.ReadAsStringAsync().Result;
                _result = JsonSerializer.Deserialize<Entity.Bing.Search>(_stringResult);
            }
            else
            {
                throw new Exception(_response.ReasonPhrase);
            }
            return _result;
        }
    }
}