namespace MystPaste.NET.Helpers.Expiry
{
    public class MystNeverExpiresIn : IMystExpiresIn
    {
        public MystNeverExpiresIn()
        {
            ExpiresIn = ExpiresIn.Never;
        }
        
        public ExpiresIn ExpiresIn { get; set; }
    }
}