namespace TinyUrlWebApi.Requests
{
    public class CreateLinkRequest
    {
        public required string LinkUrl { get; set; }

        public required string Code { get; set; }
    }
}
