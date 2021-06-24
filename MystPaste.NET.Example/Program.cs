using System;
using System.Threading.Tasks;

namespace MystPaste.NET.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var myst = new MystPasteClient();

            var res = await myst.Data.GetLanguageByNameAsync("C#");
            
            Console.WriteLine(res.Color);
            
            var ext = await myst.Data.GetLanguageByExtensionAsync(res.Extensions[0]);
            
            Console.WriteLine(ext.Name);
        }
    }
}