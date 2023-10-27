using System.Net;

namespace Service
{
    public class NetworkService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public NetworkService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetClientIp()
        {
            string ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            
            if(ipAddress == "::1")
            {
                ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[2].ToString();
            }
            return ipAddress;
        }
    }
}
