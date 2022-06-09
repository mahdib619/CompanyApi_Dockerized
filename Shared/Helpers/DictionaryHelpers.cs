namespace CompanyApp.Shared.Helpers;

public static class DictionaryHelpers
{
	public static Dictionary<string, object> FromString(string input)
	{
		return input.Split(";").Select(i => i.Split(":")).ToDictionary(kv => kv[0], kv => (object)kv[1]);
	}
}
