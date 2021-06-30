using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MystPaste.NET
{
    public class PasteClient : ApiClient
    {
        public PasteClient(ApiRequester apiRequester) : base(apiRequester)
        { }
        
        /// <summary>
        /// Gets a paste by its id.
        /// <seealso cref="GetAuthenticatedPasteAsync(string, string)"/>
        /// </summary>
        /// <param name="pasteId">The id of the paste to get.</param>
        /// <returns>A <see cref="Paste"/> object.</returns>
        public Task<Paste> GetPasteAsync(string pasteId)
        {
            return ApiRequester.Get<Paste>(ApiUrls.GetPaste(pasteId));
        }

        /// <summary>
        /// Get a private paste via id. requires auth.
        /// <seealso cref="GetPasteAsync"/>
        /// </summary>
        /// <param name="pasteId">The id of the paste to get.</param>
        /// <param name="auth">
        /// An optional authentication token.
        /// Is only optional when a token has not been passed to the <see cref="MystPasteClient"/>.
        /// </param>
        /// <returns>A <see cref="Paste"/> object.</returns>
        /// <exception cref="InvalidAuthException">Throws when an auth token has not been passed to the client or the method.</exception>
        public Task<Paste> GetAuthenticatedPasteAsync(string pasteId, string auth = null)
        {
            auth ??= ApiRequester.Auth;
            if (auth is null)
                throw new InvalidAuthException(nameof(auth));

            return ApiRequester.Get<Paste>(ApiUrls.GetPaste(pasteId), auth);
        }
        
        /// <summary>
        /// Create a new post.
        /// Requires auth (given through the paste form builder or the PasteForm)
        /// if its to be added to your profile.
        /// </summary>
        /// <param name="pasteForm">The <see cref="PasteForm"/> to be posted. See <see cref="PasteFormBuilder"/> for a builder.</param>
        public Task<Paste> PostPasteAsync(PasteForm pasteForm)
        {
            return ApiRequester.Post<Paste>(ApiUrls.PostPaste(),JsonConvert.SerializeObject(pasteForm));
        }

        /// <summary>
        /// Delete a post, requires auth.
        /// </summary>
        /// <param name="pasteId">The id of the post to delete.</param>
        /// <param name="auth"></param>
        /// <returns></returns>
        /// <exception cref="InvalidAuthException">Throws when an auth token has not been passed to the client or the method.</exception>
        public Task DeletePostAsync(string pasteId, string auth = null)
        {
            auth ??= ApiRequester.Auth;
            if (auth is null)
                throw new InvalidAuthException(nameof(auth));

            return ApiRequester.Delete(ApiUrls.DeletePost(pasteId), auth);
        }

        /// <summary>
        /// Edit a post. you can only edit posts on your account, so auth is required.
        /// </summary>
        /// <param name="pasteId">The id of the paste to edit.</param>
        /// <param name="editBuilder">A <see cref="PasteEditBuilder"/> for the edit.</param>
        /// <param name="auth"></param>
        /// <returns>A <see cref="Paste"/> object representing the edits.</returns>
        /// <exception cref="InvalidAuthException">Throws when an auth token has not been passed to the client or the method.</exception>
        public Task<Paste> EditPostAsync(string pasteId, PasteEditBuilder editBuilder, string auth = null)
        {
            auth ??= ApiRequester.Auth;
            if (auth is null)
                throw new InvalidAuthException(nameof(auth));

            return ApiRequester.Patch<Paste>(ApiUrls.EditPost(pasteId), JsonConvert.SerializeObject(editBuilder), auth);
        }
    }
}