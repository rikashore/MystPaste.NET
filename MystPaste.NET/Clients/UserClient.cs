using System;
using System.Threading.Tasks;
using MystPaste.NET.Helpers;
using MystPaste.NET.Models;

namespace MystPaste.NET.Clients
{
    // TODO Map endpoints that require auth
    public class UserClient : ApiClient
    {
        public UserClient(ApiRequester apiRequester) : base(apiRequester)
        { }

        public async Task<bool> CheckIfUserExistsAsync(string username)
        {
            return await ApiRequester.Get(ApiUrls.UserExists(username));
        }

        public async Task<User> GetUserAsync(string username)
        {
            return await ApiRequester.Get<User>(ApiUrls.User(username));
        }
    }
}