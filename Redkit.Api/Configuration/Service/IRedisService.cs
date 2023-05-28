namespace Redkit.Api.Configuration.Service
{
    public interface IRedisService
    {
        string GetValueFromKey(string key);

        void SetValue(string key, string val);
    }
}
