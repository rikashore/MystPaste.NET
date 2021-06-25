using System;
using System.Collections.Generic;
using MystPaste.NET.Helpers.Exceptions;
using MystPaste.NET.Helpers.Expiry;
using MystPaste.NET.Models;

namespace MystPaste.NET.Helpers.Builders
{
    public class PasteFormBuilder
    {
        private readonly IList<Pasty> _pasties;
        private readonly IList<string> _tags;
        
        public string Auth { get; set; }
        public string Title { get; set; }

        public string ExpiresIn { get; set; }
        
        public bool IsPrivate { get; set; }
        
        public bool IsPublic { get; set; }

        public IList<Pasty> Pasties
        {
            get => _pasties;
            set => WithPasties(value);
        }

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

        public PasteFormBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public PasteFormBuilder WithExpiresIn(ExpiresIn expiresIn)
        {
            ExpiresIn = expiresIn switch
            {
                Expiry.ExpiresIn.OneHour => "1h",
                Expiry.ExpiresIn.TwoHours => "2h",
                Expiry.ExpiresIn.TenHours => "10h",
                Expiry.ExpiresIn.OneDay => "1d",
                Expiry.ExpiresIn.TwoDays => "2d",
                Expiry.ExpiresIn.OneWeek => "1w",
                Expiry.ExpiresIn.OneMonth => "1m",
                Expiry.ExpiresIn.OneYear => "1y",
                Expiry.ExpiresIn.Never => "never",
                _ => throw new ArgumentException("Invalid ExpiresIn", nameof(expiresIn))
            };

            return this;
        }

        public PasteFormBuilder WithIsPrivate(bool isPrivate)
        {
            IsPrivate = isPrivate;
            return this;
        }

        public PasteFormBuilder WithIsPublic(bool isPublic)
        {
            IsPublic = isPublic;
            return this;
        }

        public PasteFormBuilder WithAuth(string auth)
        {
            Auth = auth;
            return this;
        }

        public PasteFormBuilder WithTags(IEnumerable<string> tags)
        {
            if (tags is null)
                throw new ArgumentNullException(nameof(tags));
            
            _tags.Clear();

            foreach (var tag in tags)
                _tags.Add(tag);

            return this;
        }

        public PasteFormBuilder WithTags(params string[] tags)
            => WithTags((IEnumerable<string>) tags);

        public PasteFormBuilder WithPasties(IEnumerable<Pasty> pasties)
        {
            if (pasties is null)
                throw new ArgumentNullException(nameof(pasties));
            
            _pasties.Clear();

            foreach (var pasty in pasties)
                _pasties.Add(pasty);

            return this;
        }

        public PasteFormBuilder WithPasties(params Pasty[] pasties)
            => WithPasties((IEnumerable<Pasty>) pasties);

        public PasteForm Build()
        {
            Validate();
            return new PasteForm
            {
                ExpiresIn = ExpiresIn,
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