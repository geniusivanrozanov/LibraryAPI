using System.Reflection;

namespace LibraryAPI.BLL.Constants;

public static class Roles
{
    private static IReadOnlyList<string>? _allRoles;
    
    public const string User = "user";
    public const string Admin = "admin";
    public static IReadOnlyList<string> AllRoles => _allRoles ??= typeof(Roles)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(f => f.FieldType == typeof(string))
        .Select(f => (string)f.GetValue(null)!)
        .ToList()
        .AsReadOnly();
}