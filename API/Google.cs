using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SearchFight.Api
{
    internal class Google: IDisposable
    {
        private HttpClient _GoogleHttpClient;
        private Entity.Google.Authentication _Authentication;

        internal Google()
        {
            this._GoogleHttpClient = new HttpClient();
            this._GoogleHttpClient.DefaultRequestHeaders.Add("Google-Auth-AppId", Constants.GoogleConfig.AuthAppId);
        }

        public void Dispose()
        {
          this._GoogleHttpClient.Dispose();
          this._GoogleHttpClient = null;
          this._Authentication = null;
        }

        internal void Auth()
        {
            byte[] _byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", Constants.GoogleConfig.AuthMail, Constants.GoogleConfig.AuthPassword));
            this._GoogleHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(_byteArray));

            HttpResponseMessage _response = this._GoogleHttpClient.PostAsync(Constants.GoogleConfig.AuthUrl, null).Result;

            if (_response.IsSuccessStatusCode)
            {
                string _stringResult = _response.Content.ReadAsStringAsync().Result;
                this._Authentication = JsonSerializer.Deserialize<Entity.Google.Authentication>(_stringResult);
            }
            else
            {
                throw new Exception(_response.ReasonPhrase);
            }
        }

        internal Entity.Google.Search Search(string word)
        {
            Entity.Google.Search _result = new Entity.Google.Search();
            this._GoogleHttpClient.DefaultRequestHeaders.Add("Google-Access-Token", this._Authentication.token.ToString());
            
            string _json = string.Format("{{\"word\":\"{0}\"}}", word);
            StringContent _stringContent = new StringContent(_json, Encoding.UTF8, "application/json");

            HttpResponseMessage _response = this._GoogleHttpClient.PostAsync(Constants.GoogleConfig.SearchUrl, _stringContent).Result;

            if (_response.IsSuccessStatusCode)
            {
                string _stringResult = _response.Content.ReadAsStringAsync().Result;
                _result = JsonSerializer.Deserialize<Entity.Google.Search>(_stringResult);
            }
            else
            {
                throw new Exception(_response.ReasonPhrase);
            }
            return _result;
        }
    }
}