public class User : LibraryItem
{
    private string _name;

    public User(string name, DateTime? createdDate = null) : base(name, createdDate)
    {
        _name = name;
    }

    public string Name{
        get{return _name; }
        set{ _name = value; }

    }
  
}