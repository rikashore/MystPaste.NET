using MystPaste.NET.Clients;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents the main client to access the API.
    /// </summary>
    public class MystPasteClient
    {
        public MystPasteClient()
        {
            var apiRequester = new ApiRequester();
            Data = new DataClient(apiRequester);
            User = new UserClient(apiRequester);
            Time = new TimeClient(apiRequester);
        }
        
        /// <summary>
        /// The <see cref="DataClient"/> to access language related data.
        /// </summary>
        public DataClient Data { get; }
        
        /// <summary>
        /// The <see cref="UserClient"/> to access user related data.
        /// </summary>
        public UserClient User { get; }
        
        /// <summary>
        /// The <see cref="TimeClient"/> to access timestamp related info.
        /// </summary>
        public TimeClient Time { get; }
    }
}