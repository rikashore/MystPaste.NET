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

            var lang = await myst.Data.GetLanguageByNameAsync("javascript");
            
            Console.WriteLine(lang.Name);

            var res = await myst.Paste.GetPasteAsync("542hebu9");
            
            Console.WriteLine();
            Console.WriteLine(res.Title);
        }
    }
}