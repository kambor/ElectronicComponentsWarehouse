namespace ElectronicsWarehouse.ApplicationServices.API.ErrorHandling;

public static class ErrorType
{
    public const string InternalServerError = "INTERNAL_SERVER_ERROR";

    public const string ValidationError = "VALIDATION_ERROR";

    public const string NotAuthenticated = "NOT_AUTHENTICATED";

    public const string Unauthorized = "UNAUTHORIZED";

    public const string NotFound = "NOT_FOUND";

    public const string UnsupportedMethod = "UNSUPPORTED_METHOD";

    public const string UnsupportedMiediaType = "UNSUPPORTED_MEDIA_TYPE";

    public const string RequestTooLarge = "RREQUEST_TOO_LARGE";

    public const string TooManyRequests = "TOO_MANY_REQUESTS";
}