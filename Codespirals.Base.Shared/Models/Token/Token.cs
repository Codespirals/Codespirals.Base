namespace Codespirals.Base
{
    public class Token : ITokenBase
    {
        private bool _isValid = true;
        public string Key { get; set; }
        public string Value { get; } = Guid.NewGuid().ToString("N");
        public int? MinutesToLive { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public bool IsValid
        {
            get { return _isValid && (MinutesToLive is null || DateTime.UtcNow <= Created.AddMinutes((double)MinutesToLive)); }
            set { _isValid = value; }
        }
        public Token(string name)
        {
            Key = name;
        }
    }
}
