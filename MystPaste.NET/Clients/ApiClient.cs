using System;

namespace MystPaste.NET.Clients
{
    /// <summary>
    /// Represents a base abstract class which all clients inherit.
    /// </summary>
    public abstract class ApiClient
    {
        protected ApiClient(ApiRequester apiRequester)
        {
            if (apiRequester is null)
                throw new ArgumentNullException(nameof(apiRequester));

            ApiRequester = apiRequester;
        }
        
        /// <summary>
        /// The <see cref="ApiRequester"/> used to make requests.
        /// </summary>
        protected ApiRequester ApiRequester { get; private set; }
    }
}