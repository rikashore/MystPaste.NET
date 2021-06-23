using System;
using System.Net;
using System.Threading.Tasks;
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
            return await ApiRequester.Get<Language>(new Uri($"{BaseUri}/data/language?name={encodedName}"));
        }
    }
}