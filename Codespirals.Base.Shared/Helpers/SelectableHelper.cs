namespace Codespirals.Base
{
    public static partial class SelectableHelper
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
                    if (propValue is ISelectableBase cast)
                    {
                        list.Add(new TSelectable { Id = cast.Id, Name = cast.Name, Description = cast.Description });
                    }
                }
                return [.. list];
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
