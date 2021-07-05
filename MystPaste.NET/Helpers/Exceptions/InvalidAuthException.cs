using System;

namespace MystPaste.NET
{
    /// <summary>
    /// An exception thrown when an authorization token has not been passed
    /// </summary>
    public class InvalidAuthException : Exception
    {
        /// <summary>
        /// An exception thrown when an authorization token has not been passed
        /// </summary>
        public InvalidAuthException(string paramName) 
            : base("An authorization token needs to be passed in the constructor of the MystPasteClient or to the method")
        {
            ParamName = paramName;
        }
        
        /// <summary>
        /// The auth param name
        /// </summary>
        public string ParamName { get; }
    }
}