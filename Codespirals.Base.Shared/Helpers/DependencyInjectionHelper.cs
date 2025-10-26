namespace Codespirals.Base;
public static class DependencyInjectionHelper
{
    public static void CheckRequiredEnvironmentalVariablesByNames(string[] names, out Dictionary<string, string> variables)
    {
        variables = [];
        for (var i = 0; i < names.Length; i++)
        {
            variables.Add(names[i] , Environment.GetEnvironmentVariable(names[i]) ?? throw new Exception($"Missing required environmental variable: {names[i]}."));
        }
    }
}
