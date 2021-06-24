﻿using System;
using MystPaste.NET.Extensions;

namespace MystPaste.NET.Helpers
{
    /// <summary>
    /// A utility class that hosts the endpoint URLs.
    /// </summary>
    public static class ApiUrls
    {
        /// <summary>
        /// The endpoint for getting languages by name.
        /// </summary>
        public static Uri LanguageByName(string language)
            => "data/language?name={0}".FormatUri(language);

        /// <summary>
        /// The endpoint for getting languages by extension.
        /// </summary>
        public static Uri LanguageByExtension(string extension)
            => "data/languageExt?extension={0}".FormatUri(extension);

        /// <summary>
        /// The endpoint to check if a user exists.
        /// </summary>
        public static Uri UserExists(string username)
            => "user/{0}/exists".FormatUri(username);

        /// <summary>
        /// The endpoint to get a user.
        /// </summary>
        public static Uri User(string username)
            => "user/{0}".FormatUri(username);

        /// <summary>
        /// The endpoint to get the authenticated user.
        /// </summary>
        public static Uri CurrentUser()
            => "user/self".FormatUri();

        /// <summary>
        /// The endpoint to get the authenticated user's paste ids.
        /// </summary>
        /// <returns></returns>
        public static Uri CurrentUserPastes()
            => "user/self/pastes".FormatUri();

        /// <summary>
        /// The endpoint to get the expiration timestamp for a paste.
        /// </summary>
        public static Uri ExpirationTimestamp(long timestamp, string duration)
            => "time/expiresInToUnixTime?createdAt={0}&expiresIn={1}".FormatUri(timestamp, duration);

        public static Uri Paste(string pasteId)
            => "paste/{0}".FormatUri(pasteId);
    }
}