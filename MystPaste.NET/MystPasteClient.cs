using System;
using MystPaste.NET.Clients;

namespace MystPaste.NET
{
    public class MystPasteClient
    {
        public MystPasteClient()
        {
            var apiRequester = new ApiRequester();
            Data = new DataClient(apiRequester);
        }
        
        public DataClient Data { get; set; }
    }
}