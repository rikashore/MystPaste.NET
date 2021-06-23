using System;
using MystPaste.NET.Extensions;

namespace MystPaste.NET.Helpers
{
    public static class ApiUrls
    {
        public static Uri LanguageByName(string language)
            => "data/language?name={0}".FormatUri(language);

        public static Uri LanguageByExtension(string extension)
            => "/data/languageExt?extension={0}".FormatUri(extension);
    }
}