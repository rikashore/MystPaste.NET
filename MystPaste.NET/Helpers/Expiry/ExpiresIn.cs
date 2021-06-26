namespace MystPaste.NET
{
    /// <summary>
    /// An enum to represent different values for expiration of a <see cref="Paste"/>.
    /// </summary>
    public enum ExpiresIn
    {
        Never,       // string form -> "never"
        OneHour,     // string form -> "1h"
        TwoHours,    // string form -> "2h"
        TenHours,    // string form -> "10h"
        OneDay,      // string form -> "1d"
        TwoDays,     // string form -> "2d"
        OneWeek,     // string form -> "1w"
        OneMonth,    // string form -> "1m"
        OneYear    // string form -> "1y"
    }
}