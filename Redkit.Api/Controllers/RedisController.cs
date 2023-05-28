using Microsoft.AspNetCore.Mvc;
using Redkit.Api.Configuration.Service;
using Redkit.Api.Model;

namespace Redkit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedisController : Controller
    {
        private readonly IRedisService _redisService;

        public RedisController(IRedisService redisService)
        {
            _redisService = redisService;
        }

        [HttpGet("get-value-from-key")]
        public IActionResult Get(string key)
        {
            var result = _redisService.GetValueFromKey(key);

            return Ok(result);
        }

        [HttpPost("set-value")]
        public IActionResult Set(SetRedisValue request)
        {
            _redisService.SetValue(request.Key, request.Value);

            return Ok(new { message = "created" });
        }
    }
}
