using System.Net;
using System.Security.Claims;

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
            
            //if(ipAddress == "::1")
            //{
            //    ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[2].ToString();
            //}
            return ipAddress;
        }

        public int GetClientId()
        {
            bool haveUserId = int.TryParse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);
            if(!haveUserId)
            {
                throw new Exception("Cannot get UserId of currently logged user.");
            }
            return userId;
        }
    }
}
