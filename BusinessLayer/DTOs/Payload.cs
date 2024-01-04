namespace BusinessLayer.DTOs
{
    public class Payload
    {
        public string AccessToken { get; set; }

        public Payload(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
