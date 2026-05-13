using System.Net;

namespace Cookie.API.Errors;

public class ApiException
{
    
    public ApiException(string statusCode, string message, string detail)
    {
        StatusCode = statusCode;
        Message = message;
        Detail = detail;
    }
    
    public string Message { get; set; }
    public string StatusCode { get; set; }
    public string Detail { get; set; }

}