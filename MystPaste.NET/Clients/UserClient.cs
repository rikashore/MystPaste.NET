using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MystPaste.NET.Helpers;
using MystPaste.NET.Helpers.Exceptions;
using MystPaste.NET.Models;

namespace MystPaste.NET.Clients
{
    // TODO Map endpoints that require auth
    /// <summary>
    /// Represents a client to get information about users.
    /// </summary>
    public class UserClient : ApiClient
    {
        public UserClient(ApiRequester apiRequester) : base(apiRequester)
        { }

        /// <summary>
        /// Check if a user exists via their username.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <returns>
        /// A boolean value representing the result. True if the user exists. False if the user doesn't exist
        /// </returns>
        public Task<bool> CheckIfUserExistsAsync(string username)
        {
            return ApiRequester.Get(ApiUrls.UserExists(username));
        }

        /// <summary>
        /// Gets a <see cref="User"/> from their username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>A <see cref="User"/> object.</returns>
        public Task<User> GetUserAsync(string username)
        {
            return ApiRequester.Get<User>(ApiUrls.User(username));
        }

        /// <summary>
        /// Gets the currently authenticated user.
        /// </summary>
        /// <param name="auth">
        /// An optional authentication token.
        /// Is only optional when a token has not been passed to the <see cref="MystPasteClient"/>.
        /// </param>
        /// <returns>A <see cref="CurrentUser"/> object.</returns>
        /// <exception cref="InvalidAuthException">Throws when an auth token has not been passed to the client or the method.</exception>
        public Task<CurrentUser> GetAuthenticatedUserAsync(string auth = null)
        {
            auth ??= ApiRequester.Auth;
            if (auth is null)
                throw new InvalidAuthException(nameof(auth));

            return ApiRequester.Get<CurrentUser>(ApiUrls.CurrentUser(), auth);
        }

        /// <summary>
        /// Gets the currently authenticated user's paste's ids.
        /// </summary>
        /// <param name="auth">
        /// The token of the user to authenticate.
        /// Is only optional when a token has not been passed to the <see cref="MystPasteClient"/>.
        /// </param>
        /// <returns>A <see cref="List{T}"/> of strings which are the Ids of the pastes.</returns>
        /// <exception cref="ArgumentNullException">Throws when an auth token has not been passed to the client or the method.</exception>
        public Task<List<string>> GetAuthenticatedUserPastesAsync(string auth = null)
        {
            auth ??= ApiRequester.Auth;
            if (auth is null)
                throw new InvalidAuthException(nameof(auth));

            return ApiRequester.Get<List<string>>(ApiUrls.CurrentUserPastes(), auth);
        }
    }
}