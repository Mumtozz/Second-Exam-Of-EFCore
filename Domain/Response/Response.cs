using System.Net;

namespace Domain.Response;

public class Response<T>
{

    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; } = new List<string>();

    public Response(T data)
    {

        StatusCode = 200;
        Data = data; 
    }
    public Response(HttpStatusCode statusCode,string error)
    {
        StatusCode = (int) statusCode;
        Errors.Add(error);
    }

    public Response(T data,HttpStatusCode statusCode,string error)
    {

        StatusCode = (int)statusCode;
        Data = data; 
        Errors.Add(error);
    }
    public Response(HttpStatusCode statusCode,List<string> errors)
    {
        StatusCode = (int)statusCode;
        Errors = errors;
    }
}
