namespace Codespirals.Base
{
    public static class EntityStatusExtensions
    {
        public static bool IsDeleted<TStatusOptions, TStatusValue>(this IHasStatus<string> item)
            where TStatusOptions : IEntityStatuses<TStatusValue>
            where TStatusValue : ISelectableBase
            => item.Status == TStatusOptions.Deleted.Id;
    }
}
