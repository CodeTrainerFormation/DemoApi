using Microsoft.Extensions.Logging;

namespace WebApi.Services
{
    public class MyService : IMyService
    {
        public MyService(ILogger<MyService> logger)
        {

        }

        public int GetValue()
        {
            return 123;
        }
    }
}
