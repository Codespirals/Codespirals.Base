namespace Codespirals.Base
{
    /// <summary>
    /// The interface that defines the email sender service.
    /// </summary>
    /// <typeparam name="TResult">The result of the operation (implementing <see cref="IResult"/>)</typeparam>
    public interface IEmailSenderService<TResult>
        where TResult : IResult
    {
        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="from">The address that sends the email</param>
        /// <param name="subject">The general subject of the email</param>
        /// <param name="body">The text of the email</param>
        /// <param name="to">The recipient as a comma separated string</param>
        /// <returns></returns>
        public Task<TResult> SendEmailAsync(string from, string subject, string body, string to);

    }
    public interface IEmailSenderService<TResult, TUser> : IEmailSenderService<TResult>
        where TResult : IResult
        where TUser : IUserBase, IHasEmail
    {
        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="from">The user that sends the email</param>
        /// <param name="subject">The general subject of the email</param>
        /// <param name="body">The text of the email</param>
        /// <param name="to">The recipients as a list of users</param>
        /// <returns></returns>
        public Task<TResult> SendEmailAsync(TUser from, string subject, string body, IEnumerable<TUser> to);
    }
}
