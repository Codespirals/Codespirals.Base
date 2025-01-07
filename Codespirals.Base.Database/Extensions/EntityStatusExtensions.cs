namespace Codespirals.Base
{
    public static class EntityStatusExtensions
    {
        public static bool IsDeleted<TEntityStatus, TStatus>(this IHasStatus<TStatus> item)
            where TEntityStatus : IEntityStatus<TStatus>
            where TStatus : IComparable
            => item.Status.CompareTo(TEntityStatus.Deleted) >= 0;
    }
}
