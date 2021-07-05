using System;
using System.Threading.Tasks;

namespace MystPaste.NET
{
    /// <summary>
    /// Represents a client to get information
    /// about expiration dates for pastes
    /// </summary>
    public class TimeClient : ApiClient
    {
        /// <summary>
        /// Represents a client to get information
        /// about expiration dates for pastes
        /// </summary>
        public TimeClient(ApiRequester apiRequester) : base(apiRequester)
        { }

        
        /// <summary>
        /// Get expiration info about a paste.
        /// </summary>
        /// <param name="createdAt">a long representing the unix timestamp when the paste was created.</param>
        /// <param name="duration">The duration, represented by an integer, for example 24, 11 etc.</param>
        /// <param name="durationType">A character representing the duration. Valid characters include 'd', 'h', 'm', 'y', 'w'.</param>
        /// <example>
        /// <code>
        /// var timestamp = await GetExpiresWhenTimestamp(1588441258, 24, 'w');
        /// </code>
        /// </example>
        /// <returns>A long representing the unix timestamp when the paste will expire.</returns>
        /// <exception cref="ArgumentException">Throws when <paramref name="durationType"/> is not a valid duration character.</exception>
        public Task<Timestamp> GetExpiresWhenTimestamp(long createdAt, int duration, string durationType)
        {
            var expiresIn = durationType switch
            {
                "1h" => ExpiresIn.OneHour,
                "2h" => ExpiresIn.TwoHours,
                "10h" => ExpiresIn.TenHours,
                "1d" => ExpiresIn.OneDay,
                "2d" => ExpiresIn.TwoDays,
                "1w" => ExpiresIn.OneWeek,
                "1m" => ExpiresIn.OneMonth,
                "1y" => ExpiresIn.OneYear,
                "never" => ExpiresIn.Never,
                _ => throw new ArgumentException("Invalid duration type character", nameof(durationType))
            };

            return GetExpiresWhenTimestamp(createdAt, expiresIn);
        }

        /// <summary>
        /// Get expiration info about a paste.
        /// </summary>
        /// <param name="createdAt">a long representing the unix timestamp when the paste was created.</param>
        /// <param name="expiresIn">a <see cref="ExpiresIn"/> that represents the expiry duration</param>
        /// <example>
        /// <code>
        /// var timestamp = await GetExpiresWhenTimestamp(1588441258, new MystExpiresIn(24, ExpiresIn.Weeks));
        /// </code>
        /// </example>
        /// <returns>A long representing the unix timestamp when the paste will expire.</returns>
        /// <exception cref="ArgumentException">Throws when <paramref name="expiresIn"/> does not have a valid <see cref="ExpiresIn"/>.</exception>
        public Task<Timestamp> GetExpiresWhenTimestamp(long createdAt, ExpiresIn expiresIn)
        {
            var durationString = expiresIn switch
            {
                ExpiresIn.OneHour => "1h",
                ExpiresIn.TwoHours => "2h",
                ExpiresIn.TenHours => "10h",
                ExpiresIn.OneDay => "1d",
                ExpiresIn.TwoDays => "2d",
                ExpiresIn.OneWeek => "1w",
                ExpiresIn.OneMonth => "1m",
                ExpiresIn.OneYear => "1y",
                ExpiresIn.Never => "never",
                _ => throw new ArgumentException("Invalid ExpiresIn", nameof(expiresIn))
            };
            

            return ApiRequester.Get<Timestamp>(ApiUrls.ExpirationTimestamp(createdAt, durationString));
        }
    }
}