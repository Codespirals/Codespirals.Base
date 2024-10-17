namespace Codespirals.Base
{
    public interface IHttpCredentialBase : IHasToken
    {
        /// <summary>
        /// A token containing the api username
        /// </summary>
        KeyValuePair<string, string> Id { get; }
    }
}
