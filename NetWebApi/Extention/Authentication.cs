using QWZE.JF.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace QWZE.JF.Extention
{
    public class Authentication
    {
        private string scope;
        public HttpClient _httpClient;
        private ConcurrentDictionary<string, TokenResponse> _TokenResponseDic = new ConcurrentDictionary<string, TokenResponse>(StringComparer.Ordinal);

        public Authentication(ScopeEnum scope)
        {
            this.scope = scope.ToString();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(KingdeeConfig.Host);
            //_httpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        }

        public async Task<string> GetCorrectToken()
        {
            TokenResponse _TokenResponse;
            _TokenResponseDic.TryGetValue(scope, out _TokenResponse);

            while (_TokenResponse == null || _TokenResponse.success == false)
            {
                _TokenResponse = await GetToken();
                if (_TokenResponse.success) _TokenResponseDic.TryAdd(scope, _TokenResponse);
            }

            while (_TokenResponse.data.expireDate < DateTime.Now || _TokenResponse.success == false)
            {
                _TokenResponse = await RefreshToken(_TokenResponse.data.refreshToken);
                if (_TokenResponse.success) _TokenResponseDic.TryUpdate(scope, _TokenResponse, _TokenResponse);
            }

            return _TokenResponse.data.accessToken;
        }

        private async Task<TokenResponse> GetToken()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("appId", KingdeeConfig.AppID);
            parameters.Add("eid", KingdeeConfig.Eid);
            parameters.Add("secret", KingdeeConfig.Secret);
            parameters.Add("scope", scope);
            parameters.Add("timestamp", TimeHelper.ConvertDateTimeToInt(DateTime.Now).ToString());

            string url = "/gateway/oauth2/token/getAccessToken";
            TokenResponse result = await CallHttpPost<TokenResponse>(url, parameters);
            result.data.expireDate = DateTime.Now.AddSeconds(result.data.expireIn);
            return result;
        }

        private async Task<TokenResponse> RefreshToken(string refreshToken)
        {
            HttpClient _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(KingdeeConfig.Host);
            var parameters = new Dictionary<string, string>();
            parameters.Add("appId", KingdeeConfig.AppID);
            parameters.Add("eid", KingdeeConfig.Eid);
            parameters.Add("refreshToken", refreshToken);
            parameters.Add("scope", scope);
            parameters.Add("timestamp", TimeHelper.ConvertDateTimeToInt(DateTime.Now).ToString());

            string url = "/gateway/oauth2/token/refreshToken";
            TokenResponse result = await CallHttpPost<TokenResponse>(url, parameters);
            result.data.expireDate = DateTime.Now.AddSeconds(result.data.expireIn);
            return result;
        }

        public async Task<T> CallHttpPost<T>(string url, Dictionary<string, string> dic)
        {
            var response = await _httpClient.PostAsync(url, new FormUrlEncodedContent(dic));
            var responseValue = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Log.saveErrorLog((await response.Content.ReadAsAsync<HttpError>()).ExceptionMessage);
                return default(T);
            }
            T result = await response.Content.ReadAsAsync<T>();
            return result;
        }

        public async Task<T> CallHttpGet<T>(string url, Dictionary<string, string> dic)
        {
            var response = await _httpClient.GetAsync(UrlHelper.SpliceUrl(url, dic));
            var responseValue = await response.Content.ReadAsStringAsync();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Log.saveErrorLog((await response.Content.ReadAsAsync<HttpError>()).ExceptionMessage);
                return default(T);
            }
            T result = await response.Content.ReadAsAsync<T>();
            return result;
        }
    }
}