using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents the class used to make API requests.
    /// </summary>
    public class ApiRequester
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseUri = new Uri("https://paste.myst.rs/api/v2/");
        private readonly ILogger _logger;

        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        /// <summary>
        /// The requester to call the API.
        /// </summary>
        /// <param name="auth">Authorization token to be used.</param>
        /// <param name="logger">The logger to use for logging</param>
        public ApiRequester(string auth, ILogger logger)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = _baseUri
            };
            _logger = logger;
            _retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(2, _ => TimeSpan.FromMinutes(2), (_, _) =>
                {
                    logger.LogInformation("Ratelimit hit, retrying");
                });

            Auth = auth;
        }
        
        /// <summary>
        /// The authorization token to be used for
        /// authorized methods.
        /// </summary>
        public string Auth { get; }

        /// <summary>
        /// Makes a GET request to the specified url.
        /// </summary>
        public async Task<T> Get<T>(Uri uri, string auth = null)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            
            if (auth is not null)
                requestMessage.Headers.TryAddWithoutValidation("Authorization", auth);

            var msg = await _retryPolicy.ExecuteAsync(async () =>
            {
                var res = await _httpClient.SendAsync(requestMessage);

                _logger?.LogInformation("Making GET request to {uri}", uri);

                if (res.IsSuccessStatusCode)
                    return res;

                var stream = await res.Content.ReadAsStreamAsync();

                var error = stream.DeserializeTo<Response>();
                throw new Exception(error is null
                    ? "The server returned an exception with unknown reasons."
                    : $"The server returned an exception: {error.ErrorMessage}");
            });

            var contentStream = await msg.Content.ReadAsStreamAsync();
            return contentStream.DeserializeTo<T>();
        }

        /// <summary>
        /// Makes a GET request to the specified url. Used to check if a resource exists.
        /// </summary>
        public async Task<bool> Get(Uri uri)
        {
            var res = await _httpClient.GetAsync(uri);
            return res.IsSuccessStatusCode;
        }

        /// <summary>
        /// Makes a POST request to the specified url.
        /// </summary>
        public async Task<T> Post<T>(Uri uri, string content, string auth = null)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            if (auth is not null)
                requestMessage.Headers.TryAddWithoutValidation("Authorization", auth);

            requestMessage.Content = new StringContent(content);

            var msg = await _retryPolicy.ExecuteAsync(async () =>
            {
                var responseMessage = await _httpClient.SendAsync(requestMessage);
                
                _logger?.LogInformation("Making POST request to {uri}", uri);
                
                var stream = await responseMessage.Content.ReadAsStreamAsync();

                if (responseMessage.IsSuccessStatusCode) 
                    return responseMessage;
                
                var error = stream.DeserializeTo<Response>();
                throw new Exception(error is null
                    ? "The server returned an exception with unknown reasons."
                    : $"The server returned an exception: {error.ErrorMessage}");

            });

            var contentStream = await msg.Content.ReadAsStreamAsync();
            return contentStream.DeserializeTo<T>();
        }

        /// <summary>
        /// Makes a DELETE request to the specified url.
        /// </summary>
        public async Task Delete(Uri uri, string auth)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            requestMessage.Headers.TryAddWithoutValidation("Authorization", auth);

                
            await _retryPolicy.ExecuteAsync(async () =>
            {
                var responseMessage = await _httpClient.SendAsync(requestMessage);
                
                _logger?.LogInformation("Making DELETE request to {uri}", uri);
                
                var stream = await responseMessage.Content.ReadAsStreamAsync();

                if (responseMessage.IsSuccessStatusCode) 
                    return responseMessage;
                
                var error = stream.DeserializeTo<Response>();
                throw new Exception(error is null
                    ? "The server returned an exception with unknown reasons."
                    : $"The server returned an exception: {error.ErrorMessage}");
            });
        }

        /// <summary>
        /// Make a PATCH request to the specified url.
        /// </summary>
        public async Task<T> Patch<T>(Uri uri, string content, string auth)
        {
            using var requestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);
            requestMessage.Headers.TryAddWithoutValidation("Authorization", auth);

            requestMessage.Content = new StringContent(content);

            var msg = await _retryPolicy.ExecuteAsync(async () =>
            {
                var responseMessage = await _httpClient.SendAsync(requestMessage);
                
                _logger?.LogInformation("Making PATCH request to {uri}", uri);
                
                var stream = await responseMessage.Content.ReadAsStreamAsync();

                if (responseMessage.IsSuccessStatusCode) 
                    return responseMessage;
                
                var error = stream.DeserializeTo<Response>();
                throw new Exception(error is null
                    ? "The server returned an exception with unknown reasons."
                    : $"The server returned an exception: {error.ErrorMessage}");

            });

            var contentStream = await msg.Content.ReadAsStreamAsync();
            return contentStream.DeserializeTo<T>();
        }
    }
}