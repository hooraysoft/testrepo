using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using TinyUrlWebApi.Requests;

namespace TinyUrlWebApi.Controllers
{
    [ApiController]
    [Route("api/redis")]
    public class RedisTestController : Controller
    {
        private readonly IConnectionMultiplexer _multiplexer;

        public RedisTestController(IConnectionMultiplexer multiplexer)
        {
            _multiplexer = multiplexer;
        }

        [HttpGet("PING")]
        public async Task<IActionResult> Ping()
        {
            var db = _multiplexer.GetDatabase();
            var result = await db.ExecuteAsync("PING");
            return Ok(result.ToString());
        }

        [HttpPost]
        public async Task<IActionResult> SetValue([FromBody] RedisAddItemRequest request)
        {
            var db = _multiplexer.GetDatabase();
            await db.StringSetAsync(request.Key, request.Value, TimeSpan.FromMinutes(request.TtlInMinutes));
            return Ok($"Set {request.Key} to {request.Value}");
        }

        [HttpGet]
        public async Task<IActionResult> GetValue(string key)
        {
            var db = _multiplexer.GetDatabase();
            var value = await db.StringGetAsync(key);
            if (value.IsNull)
            {
                return NotFound($"Key {key} not found");
            }
            return Ok(value.ToString());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteValue([FromBody] string key)
        {
            var db = _multiplexer.GetDatabase();
            bool deleted = await db.KeyDeleteAsync(key);
            if (deleted)
            {
                return Ok($"Key {key} deleted");
            }
            return NotFound($"Key {key} not found");
        }
    }
}
