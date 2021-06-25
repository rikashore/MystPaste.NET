using System;

namespace MystPaste.NET
{
    public class InvalidAuthException : Exception
    {
        public InvalidAuthException(string paramName)
        {
            Message = "An authorization token needs to be passed in the constructor of the MystPasteClient or to the method";
            ParamName = paramName;
        }

        public override string Message { get; }
        public string ParamName { get; }
    }
}