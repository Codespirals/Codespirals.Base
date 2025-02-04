namespace Codespirals.Base
{
    public static class SelectableHelper
    {
        public static List<TSelectable> GetAllowableValues<TSelectable, TSelectableEnum>()
            where TSelectable : ISelectableBase, new()
            where TSelectableEnum : IIsEnum<TSelectable>, new()
        {
            try
            {
                var list = new List<TSelectable>();
                var allowableValues = new TSelectableEnum();
                var properties = typeof(TSelectableEnum).GetProperties();
                foreach (var prop in properties)
                {
                    var propValue = prop.GetValue(allowableValues);
                    if (propValue is null)
                        continue;
                    if (propValue is TSelectable cast)
                    {
                        list.Add(cast);
                    }
                }
                return [.. list];
            }
            catch (Exception)
            {
                return [];
            }
        }
        public static TSelectable GetSelectableFromId<TSelectable, TSelectableEnum>(string? id)
            where TSelectable : ISelectableBase, new()
            where TSelectableEnum : IIsEnum<TSelectable>, new()
        {
            if (string.IsNullOrWhiteSpace(id))
                return TSelectableEnum.Default();
            return GetAllowableValues<TSelectable, TSelectableEnum>().FirstOrDefault(r => r.Id == id) ?? TSelectableEnum.Default();
        }
    }
}
