namespace AuthService.Core.ConfigSections
{
    /// <summary>
    /// The database settings.
    /// </summary>
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
