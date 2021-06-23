using System;
using System.Net.Http;
using System.Threading.Tasks;
using MystPaste.NET.Extensions;

namespace MystPaste.NET
{
    public class ApiRequester
    {
        readonly HttpClient _httpClient;

        public ApiRequester()
        {
            _httpClient = new HttpClient();
        }

        public async Task<T> Get<T>(Uri uri)
        {
            var res = await _httpClient.GetAsync(uri);
            res.EnsureSuccessStatusCode();

            var s = await res.Content.ReadAsStreamAsync();

            return s.DeserializeTo<T>();
        }
    }
}