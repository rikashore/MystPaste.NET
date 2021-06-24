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

            var res = await myst.Paste.GetPasteAsync("jejepxp3");
            
            //Console.WriteLine(res.Edits[0].EditType);
            Console.WriteLine(res.Title + " " + res.Title.GetType());
        }
    }
}