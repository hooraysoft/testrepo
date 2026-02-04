namespace TinyUrlWebApi.Requests
{
    public class RedisAddItemRequest
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
        public required int TtlInMinutes { get; set; }  
    }
}
