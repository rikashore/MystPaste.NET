using System.Threading.Tasks;
using MystPaste.NET.Helpers;
using MystPaste.NET.Models;

namespace MystPaste.NET.Clients
{
    public class PasteClient : ApiClient
    {
        public PasteClient(ApiRequester apiRequester) : base(apiRequester)
        { }

        // TODO Fix broken Json
        public async Task<Paste> GetPasteAsync(string pasteId)
        {
            return await ApiRequester.Get<Paste>(ApiUrls.Paste(pasteId));
        }
    }
}