namespace PollApi.Contracts
{
    public class Error
    {
        public Error(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
