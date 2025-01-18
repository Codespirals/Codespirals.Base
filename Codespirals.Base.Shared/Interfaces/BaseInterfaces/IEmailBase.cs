namespace Codespirals.Base
{

    public interface IEmailBase
    {
        /// <summary>
        /// The sender's email address
        /// </summary>
        string From { get; }
        /// <summary>
        /// The recipient(s)
        /// </summary>
        string To { get; }
        /// <summary>
        /// The subject line
        /// </summary>
        /// <remarks>We've been trying to reach you about your car's extended warranty</remarks>
        string Subject { get; }
        /// <summary>
        /// The text of the email in UTF-8
        /// </summary>
        string Body { get; }
    }
}
