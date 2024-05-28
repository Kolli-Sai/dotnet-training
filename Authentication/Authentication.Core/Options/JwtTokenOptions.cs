namespace Authentication.Core.Options;

public class JwtTokenOptions
{
    public string Name { get; set; } = "JwtToken";
    public string Key { get; set; } = string.Empty;
}
