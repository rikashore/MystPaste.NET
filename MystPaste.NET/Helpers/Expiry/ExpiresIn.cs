using System.Runtime.Serialization;

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
        [EnumMember(Value = "never")]
        Never,
        
        /// <summary>
        /// Represents "1h".
        /// </summary>
        [EnumMember(Value = "1h")]
        OneHour,
        
        /// <summary>
        /// Represents "2h".
        /// </summary>
        [EnumMember(Value = "2h")]
        TwoHours,
        
        /// <summary>
        /// Represents "10h".
        /// </summary>
        [EnumMember(Value = "10h")]
        TenHours,
        
        /// <summary>
        /// Represents "1d".
        /// </summary>
        [EnumMember(Value = "1d")]
        OneDay,
        
        /// <summary>
        /// Represents "2d".
        /// </summary>
        [EnumMember(Value = "2d")]
        TwoDays,
        
        /// <summary>
        /// Represents "1w".
        /// </summary>
        [EnumMember(Value = "1w")]
        OneWeek, 
        
        /// <summary>
        /// Represents "1m".
        /// </summary>
        [EnumMember(Value = "1m")]
        OneMonth,
        
        /// <summary>
        /// Represents "1y".
        /// </summary>
        [EnumMember(Value = "1y")]
        OneYear  
    }
}