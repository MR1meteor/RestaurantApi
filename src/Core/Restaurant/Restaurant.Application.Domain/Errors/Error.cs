namespace Restaurant.Application.Domain.Errors;

public class Error
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }

    public static bool operator ==(Error a, Error b)
    {
        if (a is null && b is null) return true;

        if (a is null || b is null) return false;

        return a.Code == b.Code;
    }

    public static bool operator !=(Error a, Error b)
    {
        return !(a == b);
    }

    public override bool Equals(object? obj)
    {
        var item = obj as Error;

        if (item == null) return false;

        return Code.Equals(item.Code);
    }

    public override int GetHashCode()
    {
        return Code.GetHashCode();
    }
}