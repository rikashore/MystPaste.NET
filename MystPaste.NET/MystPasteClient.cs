namespace MystPaste.NET
{
    /// <summary>
    /// Represents the main client to access the API.
    /// </summary>
    public class MystPasteClient
    {
        /// <summary>
        /// Represents an authorised MystPasteClient.
        /// </summary>
        /// <param name="auth">The token of the user to authenticate with.</param>
        public MystPasteClient(string auth)
        {
            var apiRequester = new ApiRequester(auth);
            Data = new DataClient(apiRequester);
            User = new UserClient(apiRequester);
            Time = new TimeClient(apiRequester);
            Paste = new PasteClient(apiRequester);
        }
        
        public MystPasteClient() : this(null)
        { }

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
        
        public PasteClient Paste { get; }
    }
}