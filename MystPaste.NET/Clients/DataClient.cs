using System.Net;
using System.Threading.Tasks;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents the client for getting information
    /// about programming languages.
    /// </summary>
    public class DataClient : ApiClient
    {
        /// <summary>
        /// Represents the client for getting information
        /// about programming languages.
        /// </summary>
        public DataClient(ApiRequester apiRequester) : base(apiRequester)
        { }

        /// <summary>
        /// Gets a <see cref="Language"/> via its name.
        /// </summary>
        /// <remarks>
        /// The method automatically percent encodes the string you pass in.
        /// </remarks>
        /// <exception cref="System.Net.Http.HttpRequestException">Throws when the resource requested is not found.</exception>
        /// <param name="languageName">The name of the language to get.</param>
        /// <returns>A <see cref="Language"/> object.</returns>
        public Task<Language> GetLanguageByNameAsync(string languageName)
        {
            var encodedName = WebUtility.UrlEncode(languageName);
            return ApiRequester.Get<Language>(ApiUrls.LanguageByName(encodedName));
        }

        /// <summary>
        /// Gets a <see cref="Language"/> via its extension.
        /// </summary>
        /// <remarks>
        /// The method automatically percent encodes the string you pass in.
        /// </remarks>
        /// <exception cref="System.Net.Http.HttpRequestException">Throws when the resource requested is not found.</exception>
        /// <param name="extension">The extension of the language to get.</param>
        /// <returns>A <see cref="Language"/> object.</returns>
        public Task<Language> GetLanguageByExtensionAsync(string extension)
        {
            var encodedExtension = WebUtility.UrlEncode(extension);
            return ApiRequester.Get<Language>(ApiUrls.LanguageByExtension(encodedExtension));
        }
    }
}