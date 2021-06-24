﻿using System;

namespace MystPaste.NET.Clients
{
    public abstract class ApiClient
    {
        protected ApiClient(ApiRequester apiRequester)
        {
            if (apiRequester is null)
                throw new ArgumentNullException(nameof(apiRequester));

            ApiRequester = apiRequester;
        }
        
        protected ApiRequester ApiRequester { get; private set; }
    }
}