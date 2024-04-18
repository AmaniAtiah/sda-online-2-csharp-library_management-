public class User : LibraryItem
{
    public string Name { get; set; }
    public User(string name, DateTime? createdDate = null) : base(name, createdDate)
    {
        Name = name;
    }

}