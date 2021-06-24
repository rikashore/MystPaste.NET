using MystPaste.NET.Clients;

namespace MystPaste.NET
{
    public class MystPasteClient
    {
        public MystPasteClient()
        {
            var apiRequester = new ApiRequester();
            Data = new DataClient(apiRequester);
            User = new UserClient(apiRequester);
            Time = new TimeClient(apiRequester);
        }
        
        public DataClient Data { get; set; }
        public UserClient User { get; set; }
        public TimeClient Time { get; set; }
    }
}