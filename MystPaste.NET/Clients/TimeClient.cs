using System;
using System.Threading.Tasks;
using MystPaste.NET.Helpers;
using MystPaste.NET.Helpers.Expiry;

namespace MystPaste.NET.Clients
{
    public class TimeClient : ApiClient
    {
        public TimeClient(ApiRequester apiRequester) : base(apiRequester)
        { }

        public async Task<long> GetExpiresInTimestamp(long timestamp, int duration, ExpiresIn expiresIn)
        {
            return await GetExpiresInTimestamp(timestamp, new MystExpiresIn(duration, expiresIn));
        }

        public async Task<long> GetExpiresInTimestamp(long timestamp, int duration, char durationType)
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

            return await GetExpiresInTimestamp(timestamp, duration, expiresIn);
        }

        public async Task<long> GetExpiresInTimestamp(long timestamp, IMystExpiresIn expiresIn)
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

            return await ApiRequester.Get<long>(ApiUrls.ExpirationTimestamp(timestamp, duration));
        }
    }
}