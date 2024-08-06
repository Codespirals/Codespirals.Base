namespace Codespirals.Base
{

    public interface IEmailBase
    {
        string From { get; }
        string To { get; }
        string Subject { get; }
        string Body { get; }
    }
}
