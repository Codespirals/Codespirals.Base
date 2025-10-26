namespace Codespirals.Base;
public static class DependencyInjectionHelper
{
    public static void CheckRequiredEnvironmentalVariables(string[] variables)
    {
        foreach (var item in variables)
        {
            _ = Environment.GetEnvironmentVariable(item) ?? throw new Exception("Missing required environmental variable.");
        }
    }
}
