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
        public static (int s, int m, int h, int d) TimeAgo(this DateTime time)
        {
            var utc = time.ToUniversalTime();
            var delta = DateTime.UtcNow - utc;
            return (delta.Seconds, delta.Minutes, delta.Hours, delta.Days);
        }
    }
}
