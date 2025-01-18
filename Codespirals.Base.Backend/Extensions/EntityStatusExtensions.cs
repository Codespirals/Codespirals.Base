namespace Codespirals.Base
{
    public static class EntityStatusExtensions
    {
        public static bool IsDeleted<TStatus, TStatusValue>(this IHasStatus<TStatusValue> item)
            where TStatus : IEntityStatus<TStatusValue>
            where TStatusValue : ISelectableBase
            => item.Status.Id == TStatus.Deleted.Id;
    }
}
