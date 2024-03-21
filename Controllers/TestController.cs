using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using test.Service;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //static readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect($"{HOST_NAME}:{PORT_NUMBER},password={PASSWORD}");
        //private readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("127.0.0.1:6379,password=6379");

        //public TestController(ConnectionMultiplexer redis)
        //{
        //    _redis = redis;
        //}

        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        [HttpGet("key")]
        public IActionResult get()
        {
            //var db = _redis.GetDatabase();

            //var value = db.StringGet(key);
            //return new JsonResult(value);

            //IDatabase redisDb = _redisConnection.GetDatabase();
            //redisDb.StringSet($"otp:{key}", 7, TimeSpan.FromMinutes(5));
            //string name = redisDb.StringGet("name");
            string lop = _testService.GetData();
            return Ok(lop);
        }

        [HttpPost("setkey")]
        public IActionResult post(string key,int birhtDay)
        {
            _testService.SetData(key, birhtDay);
            if (!_testService.SetData(key, birhtDay))
                return BadRequest("như shit");
            return Ok();
        }
    }
}
