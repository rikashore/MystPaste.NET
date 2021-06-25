using System;
using System.Threading.Tasks;

namespace MystPaste.NET.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var myst = new MystPasteClient();

            var lang = await myst.Data.GetLanguageByNameAsync("PGP");
            
            if (lang.Aliases is null)
                Console.WriteLine("nah no aliases");
            else
                Console.WriteLine(string.Join(" ", lang.Aliases));
            
            var lang2 = await myst.Data.GetLanguageByNameAsync("brainfuck");
            
            if (lang2.Aliases.Count == 0)
                Console.WriteLine("nah no aliases");
            else
                Console.WriteLine(string.Join(" ", lang2.Aliases));

            var paste = await myst.Paste.GetPasteAsync("jejepxp3");
            
            Console.WriteLine(paste.Title);

            var pfb = new PasteFormBuilder()
                .WithTitle("Nice")
                .Build();
        }
    }
}