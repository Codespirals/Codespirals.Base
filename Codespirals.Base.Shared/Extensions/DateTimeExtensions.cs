 namespace Codespirals.Base
{
    /// <summary>
    /// Extensions for <see cref="DateTime"/>
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Returns a tuple containing how long ago a given <see cref="DateTime"/> was
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static TimeSpan TimeAgo(this DateTime time)
        {
            var utc = time.ToUniversalTime();
            return DateTime.UtcNow - utc;
        }
    }
}
