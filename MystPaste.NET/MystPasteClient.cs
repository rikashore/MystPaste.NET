using System;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents the main client to access the API.
    /// </summary>
    public class MystPasteClient
    {
        /// <summary>
        /// Represents a client to access the API.
        /// </summary>
        /// <param name="configuration">The <see cref="MystPasteConfiguration"/> to use for this client.</param>
        public MystPasteClient(MystPasteConfiguration configuration)
        {
            var apiRequester = new ApiRequester(configuration.AuthToken, configuration.Logger);
            Data = new DataClient(apiRequester);
            User = new UserClient(apiRequester);
            Time = new TimeClient(apiRequester);
            Paste = new PasteClient(apiRequester);
        }

        /// <summary>
        /// Represents a client to access the API.
        /// </summary>
        /// <param name="action">The <see cref="MystPasteConfiguration"/> action to use for this client.</param>
        public MystPasteClient(Action<MystPasteConfiguration> action)
        {
            var properties = new MystPasteConfiguration();
            action?.Invoke(properties);
            
            var apiRequester = new ApiRequester(properties.AuthToken, properties.Logger);
            Data = new DataClient(apiRequester);
            User = new UserClient(apiRequester);
            Time = new TimeClient(apiRequester);
            Paste = new PasteClient(apiRequester);
        }

        /// <summary>
        /// Represents a client to access the API.
        /// </summary>
        public MystPasteClient() : this(new MystPasteConfiguration
        {
            AuthToken = null,
            Logger = null
        })
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
        
        /// <summary>
        /// The <see cref="PasteClient"/> to access pastes and paste related info.
        /// </summary>
        public PasteClient Paste { get; }
    }
}