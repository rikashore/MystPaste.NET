using System;
using System.Net;
using System.Threading.Tasks;
using MystPaste.NET.Helpers;
using MystPaste.NET.Models;

namespace MystPaste.NET.Clients
{
    public class DataClient : ApiClient
    {
        public DataClient(ApiRequester apiRequester) : base(apiRequester)
        { }

        public async Task<Language> GetLanguageByNameAsync(string languageName)
        {
            var encodedName = WebUtility.UrlEncode(languageName);
            return await ApiRequester.Get<Language>(ApiUrls.LanguageByName(encodedName));
        }

        public async Task<Language> GetLanguageByExtensionAsync(string extension)
        {
            var encodedExtension = WebUtility.UrlEncode(extension);
            return await ApiRequester.Get<Language>(ApiUrls.LanguageByExtension(encodedExtension));
        }
    }
}