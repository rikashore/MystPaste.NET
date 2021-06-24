using System;
using System.Threading.Tasks;
using MystPaste.NET.Helpers.Expiry;

namespace MystPaste.NET.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var myst = new MystPasteClient();

            var res = await myst.Data.GetLanguageByNameAsync("C#");
            
            Console.WriteLine(res.HexColor);
            
            var ext = await myst.Data.GetLanguageByExtensionAsync(res.Extensions[0]);
            
            Console.WriteLine(ext.Name);

            var timestamp = await myst.Time.GetExpiresWhenTimestamp(1588441258, new MystExpiresIn(1, ExpiresIn.Weeks));

            // var self = await myst.User.GetCurrentUserAsync();
            
            Console.WriteLine(timestamp.ExpirationDate);
        }
    }
}