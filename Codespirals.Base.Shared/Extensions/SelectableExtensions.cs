namespace Codespirals.Base.Shared.Extensions
{
    public static class SelectableExtensions
    {
        public static List<TSelectable> Unfurl<TSelectable, TSelectableEnum>(this TSelectableEnum selectableEnum)
            where TSelectable : ISelectableBase, new()
            where TSelectableEnum : IIsEnum
        {
            if (selectableEnum is null)
                return [];

            var properties = typeof(TSelectableEnum).GetProperties();
            var result = new List<TSelectable>();
            foreach (var prop in properties)
            {
                if (prop is ISelectableBase)
                {
                    var propValue = (ISelectableBase?)prop.GetValue(selectableEnum);
                    if (propValue is null)
                        break;
                    result.Add(new TSelectable { Id = propValue.Id, Name = propValue.Name, Description = propValue.Description });
                }
            }
            return result;
        }
    }
}
