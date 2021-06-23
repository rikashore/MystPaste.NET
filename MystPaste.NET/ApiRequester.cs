using System;
using System.Net.Http;
using System.Threading.Tasks;
using MystPaste.NET.Extensions;

namespace MystPaste.NET
{
    public class ApiRequester
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseUri = new Uri("https://paste.myst.rs/api/v2/");

        public ApiRequester()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> Get<T>(Uri uri)
        {
            var res = await _httpClient.GetAsync(new Uri(_baseUri, uri));
            res.EnsureSuccessStatusCode();

            var s = await res.Content.ReadAsStreamAsync();

            return s.DeserializeTo<T>();
        }
    }
}