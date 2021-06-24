using System;
using System.Threading.Tasks;
using MystPaste.NET.Helpers;
using MystPaste.NET.Helpers.Expiry;
using MystPaste.NET.Models;

namespace MystPaste.NET.Clients
{
    /// <summary>
    /// Represents a client to get information
    /// about expiration dates for pastes
    /// </summary>
    public class TimeClient : ApiClient
    {
        public TimeClient(ApiRequester apiRequester) : base(apiRequester)
        { }

        /// <summary>
        /// Get expiration info about a paste.
        /// </summary>
        /// <param name="createdAt">a long representing the unix timestamp when the paste was created.</param>
        /// <param name="duration">The duration, represented by an integer, for example 24, 11 etc.</param>
        /// <param name="expiresIn">A <see cref="ExpiresIn"/> that specifies when the paste expires.</param>
        /// <example>
        /// <code>
        /// var timestamp = await GetExpiresWhenTimestamp(1588441258, 24, ExpiresIn.Weeks);
        /// </code>
        /// </example>
        /// <returns>A long representing the unix timestamp when the paste will expire.</returns>
        public async Task<Timestamp> GetExpiresWhenTimestamp(long createdAt, int duration, ExpiresIn expiresIn)
        {
            return await GetExpiresWhenTimestamp(createdAt, new MystExpiresIn(duration, expiresIn));
        }

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
        public async Task<Timestamp> GetExpiresWhenTimestamp(long createdAt, int duration, char durationType)
        {
            var expiresIn = durationType switch
            {
                'd' => ExpiresIn.Days,
                'h' => ExpiresIn.Hours,
                'm' => ExpiresIn.Months,
                'y' => ExpiresIn.Years,
                'w' => ExpiresIn.Weeks,
                _ => throw new ArgumentException("Invalid duration type character", nameof(durationType))
            };

            return await GetExpiresWhenTimestamp(createdAt, duration, expiresIn);
        }

        /// <summary>
        /// Get expiration info about a paste.
        /// </summary>
        /// <param name="createdAt">a long representing the unix timestamp when the paste was created.</param>
        /// <param name="expiresIn">a <see cref="IMystExpiresIn"/> that represents the expiry duration</param>
        /// <example>
        /// <code>
        /// var timestamp = await GetExpiresWhenTimestamp(1588441258, new MystExpiresIn(24, ExpiresIn.Weeks));
        /// </code>
        /// </example>
        /// <returns>A long representing the unix timestamp when the paste will expire.</returns>
        /// <exception cref="ArgumentException">Throws when <paramref name="expiresIn"/> does not have a valid <see cref="ExpiresIn"/>.</exception>
        public async Task<Timestamp> GetExpiresWhenTimestamp(long createdAt, IMystExpiresIn expiresIn)
        {
            var duration = string.Empty;
            
            if (expiresIn is MystNeverExpiresIn)
                duration = "never";
            
            else if (expiresIn is MystExpiresIn mystExpiresIn)
            {
                var durationChar = mystExpiresIn.ExpiresIn switch
                {
                    ExpiresIn.Days => 'd',
                    ExpiresIn.Hours => 'h',
                    ExpiresIn.Months => 'm',
                    ExpiresIn.Years => 'y',
                    ExpiresIn.Weeks => 'w',
                    _ => throw new ArgumentException("Invalid ExpiresIn", nameof(expiresIn))
                };

                duration = $"{mystExpiresIn.Duration}{durationChar}";
            }

            return await ApiRequester.Get<Timestamp>(ApiUrls.ExpirationTimestamp(createdAt, duration));
        }
    }
}