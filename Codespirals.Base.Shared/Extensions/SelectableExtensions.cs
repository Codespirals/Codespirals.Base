namespace Codespirals.Base
{
    public static class SelectableExtensions
    {
        public static List<TSelectable> ToEnum<TSelectable, TSelectableEnum>(this TSelectableEnum selectableEnum)
            where TSelectable : ISelectableBase, new()
            where TSelectableEnum : IIsEnum
        {
            if (selectableEnum is null)
                return [];

            var properties = typeof(TSelectableEnum).GetProperties();
            var result = new List<TSelectable>();
            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(selectableEnum);
                if (propValue is null)
                    break;
                if (propValue is ISelectableBase cast)
                {
                    result.Add(new TSelectable { Id = cast.Id, Name = cast.Name, Description = cast.Description });
                }
            }
            return result;
        }
    }
}
