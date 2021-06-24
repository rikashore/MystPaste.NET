namespace MystPaste.NET.Helpers.Expiry
{
    public class MystExpiresIn : IMystExpiresIn
    {
        public MystExpiresIn(int duration, ExpiresIn expiresIn)
        {
            Duration = duration;
            ExpiresIn = expiresIn;
        }
        
        public int Duration { get; set; }
        public ExpiresIn ExpiresIn { get; set; }
    }
}