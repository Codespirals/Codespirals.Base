namespace Codespirals.Base;
public static class DependencyInjectionHelper
{
    public static void CheckRequiredEnvironmentalVariablesByNames(IEnumerable<string> names)
    {
        for (var i = 0; i < names.Count(); i++)
        {
           var _ = Environment.GetEnvironmentVariable(names.ElementAt(i)) ?? throw new Exception($"Missing environmental variable: {names.ElementAt(i)}.");
        }
    }
}
