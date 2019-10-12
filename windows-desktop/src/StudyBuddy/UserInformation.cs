/// <summary>
/// Summary description for Class1
/// </summary>
public class UserInformation
{
    public UserInformation()
    {
        Username = "User";
    }

    public UserInformation(string name)
    {
        Username = name;
    }

    public string Username { get; }

    public override string ToString()
    {
        return Username;
    }
}