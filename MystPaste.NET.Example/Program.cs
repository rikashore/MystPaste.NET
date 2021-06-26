using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MystPaste.NET.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Instantiating a new MystPasteClient. We use this to make requests and get information.
            // An authorization token can be passed to constructor for making requests that require authorization.
            // Alternatively you can pass them to the methods that require auth.
            var myst = new MystPasteClient("<TOKEN HERE>");

            // The data client allows us to get info about programming langauges
            
            // Here we are getting a language by name.
            var lang = await myst.Data.GetLanguageByNameAsync("javascript");
            
            if (lang.Aliases is null)
                Console.WriteLine("nah no aliases");
            else
                Console.WriteLine(string.Join(" ", lang.Aliases));
            
            // Here we get a language by extension, C# in this case.
            var lang2 = await myst.Data.GetLanguageByExtensionAsync("cs");
            
            Console.WriteLine(lang2.Name);

            // The paste client allows us to create, get, edit and delete posts.
            
            // Allows us to get public pastes.
            var paste = await myst.Paste.GetPasteAsync("<PASTE ID>");

            Console.WriteLine(paste.Title);
            
            // This method allows us to get private posts with auth.
            var paste2 = await myst.Paste.GetAuthenticatedPasteAsync("<PASTE ID>", "<AUTH TOKEN HERE>");

            // This builder allows us to create new pastes. All pastes require at least one pasty object.
            var pfb = new PasteFormBuilder()
                .WithTitle("Nice")
                .WithPasties(new Pasty
                {
                    Title = "Test",
                    Code = "Console.WriteLine(\"Hello MystPaste\")",
                    Language = "C#"
                })
                .Build();

            // post the paste onto PasteMyst.
            await myst.Paste.PostPasteAsync(pfb);

            // Deletes a post.
            // You can only delete posts on your account, so auth is required.
            await myst.Paste.DeletePostAsync("<PASTE ID>", "<AUTH TOKEN>");

            // Get a paste and turn it into an editable form.
            var editablePaste = await myst.Paste.GetPasteAsync("<PASTE ID>");
            var form = editablePaste.CreateEditForm();

            // Edit the values.
            form.Title += "Hello";
            form.Tags = new List<string> {"test", "c#"};

            // Finally make the changes.
            await myst.Paste.EditPostAsync("<PASTE ID>", form, "<AUTH TOKEN>");
            
            // The time client allows you to get expiration info about a post based on their timestamp.
            
            // Pass in the id of the paste and when it expires, it will return a tiestamp object which contains the unix timestamp
            // of when the paste expires.
            var expirationInfo = await myst.Time.GetExpiresWhenTimestamp(123456789, ExpiresIn.OneDay);
            
            Console.WriteLine(expirationInfo.ExpirationDate);
            
            // The user client allows you to get info relating to users.
            
            // Check if a user exists. returns a boolean
            var userExists = await myst.User.CheckIfUserExistsAsync("username");

            // Get a user by their username.
            var user = await myst.User.GetUserAsync("username");
            
            Console.WriteLine(user.Username);
            
            // Get the currently authenticated user. requires auth.
            var currentUser = await myst.User.GetAuthenticatedUserAsync("<AUTH TOKEN>");
            
            Console.WriteLine(currentUser.Stars.Count);
            
            // Get a list of the currently authenticated user's paste ids.
            var pasteIds = await myst.User.GetAuthenticatedUserPastesAsync("<AUTH TOKEN>");
            
            Console.WriteLine(string.Join(' ', pasteIds));
        }
    }
}