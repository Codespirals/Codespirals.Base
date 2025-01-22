namespace Codespirals.Base
{
    public static class EntityStatusExtensions
    {
        public static bool IsDeleted<TStatusOptions, TStatusValue>(this IHasStatus<TStatusValue> item)
            where TStatusOptions : IEntityStatuses<TStatusValue>
            where TStatusValue : ISelectableBase
            => item.Status.Id == TStatusOptions.Deleted.Id;
    }
}
