namespace Restaurant.Application.Domain.Errors;

public static class Errors
{
    public static class General
    {
        public static Error AccessDenied()
        {
            return new Error("access.denied", "Access denied");
        }

        public static Error InvalidValidation()
        {
            return new Error("invalid.validation", "Model is not valid");
        }

        public static Error InvalidValidation(string modelName)
        {
            return new Error("invalid.validation", $"Model '{modelName}' is not valid");
        }

        public static Error ObjectNotFound(string entityName)
        {
            return new Error("object.not.found", $"{entityName} not found");
        }
    }
}