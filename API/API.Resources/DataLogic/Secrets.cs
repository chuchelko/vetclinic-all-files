namespace API.Resources.DataLogic
{
    public class Secrets
    {
        public readonly static string ConnectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ??
                                               "Host=localhost;Username=postgres;Password=password;Database=vetclinicdb";

        public readonly static string Salt = Environment.GetEnvironmentVariable("PASSWORD_SALT") ??
                                               "salt";
    }
}