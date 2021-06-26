using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents the class used to make API requests.
    /// </summary>
    public class ApiRequester
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseUri = new Uri("https://paste.myst.rs/api/v2/");

        public ApiRequester(string auth)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = _baseUri
            };

            Auth = auth;
        }
        
        public string Auth { get; }

        /// <summary>
        /// Makes a GET request to the specified url.
        /// </summary>
        public async Task<T> Get<T>(Uri uri, string auth = null)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            
            if (auth is not null)
                requestMessage.Headers.TryAddWithoutValidation("Authorization", auth);
            
            var res = await _httpClient.SendAsync(requestMessage);
            var s = await res.Content.ReadAsStreamAsync();

            if (!res.IsSuccessStatusCode)
            {
                var err = s.DeserializeTo<Response>();
                throw new Exception(err is null
                    ? "The server returned an exception with unknown reasons."
                    : $"The server returned an exception: {err.ErrorMessage}");
            }
            
            return s.DeserializeTo<T>();
        }

        /// <summary>
        /// Makes a GET request to the specified url. Used to check if a resource exists.
        /// </summary>
        public async Task<bool> Get(Uri uri)
        {
            var res = await _httpClient.GetAsync(uri);
            return res.IsSuccessStatusCode;
        }

        public async Task Post(Uri uri, string content, string auth = null)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            if (auth is not null)
                requestMessage.Headers.TryAddWithoutValidation("Authorization", auth);

            requestMessage.Content = new StringContent(content);

            var res = await _httpClient.SendAsync(requestMessage);
            var s = await res.Content.ReadAsStreamAsync();

            if (!res.IsSuccessStatusCode)
            {
                var err = s.DeserializeTo<Response>();
                throw new Exception(err is null
                    ? "The server returned an exception with unknown reasons."
                    : $"The server returned an exception: {err.ErrorMessage}");
            }
        }

        public async Task Delete(Uri uri, string auth)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            requestMessage.Headers.TryAddWithoutValidation("Authorization", auth);
            
            var res = await _httpClient.SendAsync(requestMessage);
            var s = await res.Content.ReadAsStreamAsync();

            if (!res.IsSuccessStatusCode)
            {
                var err = s.DeserializeTo<Response>();
                throw new Exception(err is null
                    ? "The server returned an exception with unknown reasons."
                    : $"The server returned an exception: {err.ErrorMessage}");
            }
        }

        public async Task<T> Patch<T>(Uri uri, string content, string auth)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);
            requestMessage.Headers.TryAddWithoutValidation("Authorization", auth);

            requestMessage.Content = new StringContent(content);

            var res = await _httpClient.SendAsync(requestMessage);
            var s = await res.Content.ReadAsStreamAsync();

            if (!res.IsSuccessStatusCode)
            {
                var err = s.DeserializeTo<Response>();
                throw new Exception(err is null
                    ? "The server returned an exception with unknown reasons."
                    : $"The server returned an exception: {err.ErrorMessage}");
            }

            return s.DeserializeTo<T>();
        }
    }
}