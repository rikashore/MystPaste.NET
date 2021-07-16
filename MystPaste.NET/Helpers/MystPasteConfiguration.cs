using Microsoft.Extensions.Logging;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents a configuration for the <see cref="MystPasteClient"/>.
    /// </summary>
    public sealed class MystPasteConfiguration
    {
        /// <summary>
        /// The optional authorization token for the client.
        /// </summary>
        public string AuthToken { internal get; set; }

        /// <summary>
        /// The optional logger to use for logging.
        /// </summary>
        public ILogger Logger { internal get; set; }
    }
}