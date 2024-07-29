namespace Airline.Infrastructure.Configurations;

public static class ConfigurationDefaults
{
    public const int DefaultStringLength = 255;
    public const int MaxStringLength = 500;
    public const int PhoneNumberLength = 13;

    public const string ConectionString = "Data Source=model@localhost ;Initial Catalog=Airline.DataBase;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True";
    // "Server=myServerAddress; Database=myDataBase; User Id=myUsername; Password=myPassword;"
}