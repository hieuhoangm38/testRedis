
using StackExchange.Redis;
using System.Text.Json;

namespace test.Service
{
    public interface ITestService
    {
        T GetData<T>(string key);
        bool SetData<T>(string key, T value);
        object RemoveData(string key);
        string GetData();
    }

    public class TestService : ITestService
    {
        private readonly IDatabase _database;

        public TestService()
        {
            var redisDB = ConnectionMultiplexer.Connect("127.0.0.1:6379,allowAdmin=true");
            _database = redisDB.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = _database.StringGet(key);
            if (!string.IsNullOrEmpty(value))
                return JsonSerializer.Deserialize<T>(value);
            return default;
        }

        public object RemoveData(string key)
        {
            var exist = _database.KeyExists(key);

            if(exist)
                return _database.KeyDelete(key);
            return false;
        }

        public bool SetData<T>(string key, T value)
        {
            //expirtyTime thời gian hết hạn
            //var expirtyTime = expirationTime.DateTime.Subtract(DateTime.Now);
            return _database.StringSet(key, JsonSerializer.Serialize(value), TimeSpan.FromMinutes(2));
        }

        public string GetData()
        {
            _database.HashSet("myHash", new HashEntry[] {
                new HashEntry("field1", "value1"),
                new HashEntry("field2", "value2"),
                new HashEntry("field3", "value3")
            });
            string chuoi = _database.HashGet("field1", "value1");

            return chuoi;
        }
    }
}
