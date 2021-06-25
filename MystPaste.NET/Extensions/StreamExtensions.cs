using System.IO;
using Newtonsoft.Json;

namespace MystPaste.NET
{
    internal static class StreamExtensions
    {
        internal static T DeserializeTo<T>(this Stream s)
        {
            using var reader = new StreamReader(s);
            using (var jsonTextReader = new JsonTextReader(reader))
            {
                var ser = new JsonSerializer();
                return ser.Deserialize<T>(jsonTextReader);
            }
        }
    }
}