using System.IO;
using Newtonsoft.Json;

namespace MystPaste.NET.Extensions
{
    public static class StreamExtensions
    {
        public static T DeserializeTo<T>(this Stream s)
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