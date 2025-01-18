namespace Codespirals.Base
{
    public static class EntityStatusExtensions
    {
        public static bool IsDeleted<TStatus>(this IHasStatus<string> item)
            where TStatus : IEntityStatus
            => item.Status == TStatus.Deleted;
    }
}
