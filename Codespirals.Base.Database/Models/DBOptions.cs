namespace Codespirals.Base
{
    public class DBOptions
    {
        public string Server { get; set; } = string.Empty;
        public string Database { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string BuildConnectionString()
            => $"Server={Server};Database={Database};UserId={Username};Password={Password}";
    }
}
