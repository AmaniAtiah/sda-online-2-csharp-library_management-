public class User : LibraryItem
{
    private string _name;

    public User(string name, DateTime createdDate) : base(createdDate)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

}