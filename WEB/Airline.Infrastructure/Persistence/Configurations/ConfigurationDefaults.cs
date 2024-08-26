namespace Airline.Infrastructure.Persistence.Configurations;

public static class ConfigurationDefaults
{
    public const int DefaultStringLength = 255;
    public const int MaxStringLength = 500;
    public const int PhoneNumberLength = 13;

    public const string ConectionString = "Server=localhost; Database=AirlineDataBase; User Id=sa; Password=MyP@ssw0rd123; TrustServerCertificate=True;";
}