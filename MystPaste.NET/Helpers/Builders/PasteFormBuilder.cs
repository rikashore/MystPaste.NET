using System;
using System.Collections.Generic;

namespace MystPaste.NET
{
    /// <summary>
    /// A builder to create a <see cref="Paste"/> to post.
    /// </summary>
    public class PasteFormBuilder
    {
        private readonly IList<Pasty> _pasties;
        private readonly IList<string> _tags;
        
        /// <summary>
        /// The authorization. Required if the post is to be tied to your account.
        /// Made public/private or have tags.
        /// </summary>
        public string Auth { get; set; }
        
        /// <summary>
        /// The tile of the paste.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The string representing the time it expires in.
        /// </summary>
        public string ExpiresInString { get; set; }
        
        /// <summary>
        /// Whether the post is private. Requires auth.
        /// </summary>
        public bool IsPrivate { get; set; }
        
        /// <summary>
        /// Whether the post is public. Requires auth.
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// A list of <see cref="Pasty"/> objects.
        /// </summary>
        public IList<Pasty> Pasties
        {
            get => _pasties;
            set => WithPasties(value);
        }

        /// <summary>
        /// A list of strings representing the tags of the post.
        /// Requires auth.
        /// </summary>
        public IList<string> Tags
        {
            get => _tags;
            set => WithTags(value);
        }

        public PasteFormBuilder()
        {
            _pasties = new List<Pasty>();
            _tags = new List<string>();
        }

        /// <summary>
        /// Set the title.
        /// </summary>
        /// <param name="title">The title to have for the paste.</param>
        /// <returns>This object to allow for method chaining.</returns>
        public PasteFormBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        /// <summary>
        /// Set when the post expires in.
        /// </summary>
        /// <param name="expiresIn">the <see cref="ExpiresIn"/> to set.</param>
        /// <returns>This object to allow for method chaining.</returns>
        /// <exception cref="ArgumentException">Throws when an invalid <paramref name="expiresIn"/> is passed.</exception>
        public PasteFormBuilder WithExpiresIn(ExpiresIn expiresIn)
        {
            ExpiresInString = expiresIn switch
            {
                ExpiresIn.OneHour => "1h",
                ExpiresIn.TwoHours => "2h",
                ExpiresIn.TenHours => "10h",
                ExpiresIn.OneDay => "1d",
                ExpiresIn.TwoDays => "2d",
                ExpiresIn.OneWeek => "1w",
                ExpiresIn.OneMonth => "1m",
                ExpiresIn.OneYear => "1y",
                ExpiresIn.Never => "never",
                _ => throw new ArgumentException("Invalid ExpiresIn", nameof(expiresIn))
            };

            return this;
        }

        /// <summary>
        /// Set if the post is private. Requires auth.
        /// </summary>
        /// <param name="isPrivate">A boolean representing if the post is private.</param>
        /// <returns>This object to allow for method chaining.</returns>
        public PasteFormBuilder WithIsPrivate(bool isPrivate)
        {
            IsPrivate = isPrivate;
            return this;
        }

        /// <summary>
        /// Set if the post is public. Requires auth.
        /// </summary>
        /// <param name="isPublic">A boolean representing if the post is public.</param>
        /// <returns>This object to allow for method chaining.</returns>
        public PasteFormBuilder WithIsPublic(bool isPublic)
        {
            IsPublic = isPublic;
            return this;
        }

        /// <summary>
        /// Set the token for authorization.
        /// </summary>
        /// <param name="auth">The token of the account to relate this post to.</param>
        /// <returns>This object to allow for method chaining.</returns>
        public PasteFormBuilder WithAuth(string auth)
        {
            Auth = auth;
            return this;
        }

        /// <summary>
        /// Sets the tags of this paste.
        /// </summary>
        /// <param name="tags">An <see cref="IEnumerable{T}"/> of strings to set as the tags.</param>
        /// <returns>This object to allow for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Throws when tags are null.</exception>
        public PasteFormBuilder WithTags(IEnumerable<string> tags)
        {
            if (tags is null)
                throw new ArgumentNullException(nameof(tags));
            
            _tags.Clear();

            foreach (var tag in tags)
                _tags.Add(tag);

            return this;
        }

        /// <summary>
        /// Sets the tags of this paste.
        /// </summary>
        /// <param name="tags">An array of strings to set as the tags.</param>
        /// <returns>This object to allow for method chaining.</returns>
        public PasteFormBuilder WithTags(params string[] tags)
            => WithTags((IEnumerable<string>) tags);

        /// <summary>
        /// Sets the <see cref="Pasty"/> objects for this paste.
        /// </summary>
        /// <param name="pasties">An <see cref="IEnumerable{T}"/> of <see cref="Pasty"/> objects to set as the pasties.</param>
        /// <returns>This object to allow for method chaining.</returns>
        /// <exception cref="ArgumentNullException">Throws when pasties is null.</exception>
        public PasteFormBuilder WithPasties(IEnumerable<Pasty> pasties)
        {
            if (pasties is null)
                throw new ArgumentNullException(nameof(pasties));
            
            _pasties.Clear();

            foreach (var pasty in pasties)
                _pasties.Add(pasty);

            return this;
        }

        /// <summary>
        /// Sets the <see cref="Pasty"/> objects for this paste.
        /// </summary>
        /// <param name="pasties">An <see cref="IEnumerable{T}"/> of <see cref="Pasty"/> objects to set as the pasties.</param>
        /// <returns>This object to allow for method chaining.</returns>
        public PasteFormBuilder WithPasties(params Pasty[] pasties)
            => WithPasties((IEnumerable<Pasty>) pasties);

        /// <summary>
        /// Create a <see cref="PasteForm"/> to post.
        /// </summary>
        /// <returns>A <see cref="PasteForm"/> object.</returns>
        public PasteForm Build()
        {
            Validate();
            return new PasteForm
            {
                ExpiresIn = ExpiresInString,
                Title = Title,
                IsPublic = IsPublic,
                IsPrivate = IsPrivate,
                Tags = Tags,
                Pasties = Pasties
            };
        }

        private void Validate()
        {
            if ((IsPrivate || IsPublic) && Auth is null)
                throw new InvalidAuthException(nameof(Auth));

            if (Tags is not null && Auth is null)
                throw new InvalidAuthException(nameof(Auth));

            if (Pasties.Count < 1)
                throw new ArgumentException("You need to have at least one pasty object");
        }

        public static implicit operator PasteForm(PasteFormBuilder p) => p.Build();
    }
}