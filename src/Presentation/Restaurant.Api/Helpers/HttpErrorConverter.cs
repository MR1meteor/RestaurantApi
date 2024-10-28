using System.Net;
using Restaurant.Application.Domain.Errors;

namespace Restaurant.Api.Helpers;

public static class HttpErrorConverter
{
    public static HttpStatusCode ConvertToHttp(Error error)
    {
        switch (error)
        {
            case var _ when error == Errors.General.AccessDenied():
                return HttpStatusCode.Forbidden;
            default:
                return HttpStatusCode.BadRequest;
        }
    }
}