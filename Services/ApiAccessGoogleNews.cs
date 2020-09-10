using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AspNetCoreWebAPI.Models;
using Newtonsoft.Json;

namespace AspNetCoreWebAPI.Services
{
    public sealed class ApiAccessGoogleNews
    {
        private string baseAddressGoogleAPI = "http://newsapi.org/v2/";
        private string apiKey = "4a7532ca167e44228eafd90db49fa4c1";
        private readonly HttpClient _client;
        public ApiAccessGoogleNews()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            _client = new HttpClient(handler);
            _client.BaseAddress = new System.Uri(baseAddressGoogleAPI);
            _client.DefaultRequestHeaders.Add("Accept-Encoding","gzip");
        }

        public async Task<TopHeadlines> GetArticlesTopHeadlines(string pais)
        {
            HttpResponseMessage response = await _client.GetAsync($"top-headlines?country={pais}&apiKey={apiKey}");

            if(response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            string responseJson = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TopHeadlines>(responseJson);

        }
    }
}