namespace BAS24.Libs.SpecialPassword;

public class SpecialPasswordUserOptions
{
    public string Password { get; set; } = string.Empty;
    public DateTime ExpiredAt { get; set; }
}

public class SpecialPasswordOptions
{
    private IEnumerable<SpecialPasswordUserOptions> _user;
    public IEnumerable<SpecialPasswordUserOptions> Users
    {
        get => _user;
        set => _user = value;
    }
}