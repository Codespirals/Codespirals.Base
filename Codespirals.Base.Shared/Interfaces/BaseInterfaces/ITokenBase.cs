namespace Codespirals.Base
{
    /// <summary>
    /// A simple token usually for HTTP use
    /// </summary>
    /// <remarks>While it would make sense to use a <see cref="KeyValuePair"/>, storing those in a database can cause issues I wish to avoid.</remarks>
    public interface ITokenBase : ICreatable
    {
        public string Key { get; }
        public string Value { get; }
        public int? MinutesToLive { get; }
        public bool IsValid { get; }
    }
}
