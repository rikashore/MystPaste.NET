using System;
using MystPaste.NET.Clients;

namespace MystPaste.NET
{
    public class MystPasteClient
    {
        public MystPasteClient()
        {
            var apiRequester = new ApiRequester();
            DataClient = new DataClient(apiRequester);
        }
        
        public DataClient DataClient { get; set; }
    }
}