using System.Threading.Tasks;
using MystPaste.NET.Helpers;
using MystPaste.NET.Helpers.Exceptions;
using MystPaste.NET.Models;

namespace MystPaste.NET.Clients
{
    public class PasteClient : ApiClient
    {
        public PasteClient(ApiRequester apiRequester) : base(apiRequester)
        { }
        
        public Task<Paste> GetPasteAsync(string pasteId)
        {
            return ApiRequester.Get<Paste>(ApiUrls.Paste(pasteId));
        }

        public Task<Paste> GetPasteAsync(string pasteId, string auth)
        {
            auth ??= ApiRequester.Auth;
            if (auth is null)
                throw new InvalidAuthException(nameof(auth));

            return ApiRequester.Get<Paste>(ApiUrls.Paste(pasteId), auth);
        }
    }
}