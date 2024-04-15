public class User : LibraryItem
{
    private string _name;

    public User(string _name, DateTime _createdDate) : base(_name, _createdDate)
    {
        this._name = _name;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string _name)
    {
        this._name = _name;
    }

}