namespace MystPaste.NET
{
    /// <summary>
    /// An enum to represent different values for expiration of a <see cref="Paste"/>.
    /// </summary>
    public enum ExpiresIn
    {
        /// <summary>
        /// Represents "never"
        /// </summary>
        Never,
        
        /// <summary>
        /// Represents "1h".
        /// </summary>
        OneHour,
        
        /// <summary>
        /// Represents "2h".
        /// </summary>
        TwoHours,
        
        /// <summary>
        /// Represents "10h".
        /// </summary>
        TenHours,
        
        /// <summary>
        /// Represents "1d".
        /// </summary>
        OneDay,
        
        /// <summary>
        /// 
        /// </summary>
        TwoDays,
        
        /// <summary>
        /// Represents "1w".
        /// </summary>
        OneWeek, 
        
        /// <summary>
        /// Represents "1m".
        /// </summary>
        OneMonth,
        
        /// <summary>
        /// Represents "1y".
        /// </summary>
        OneYear  
    }
}