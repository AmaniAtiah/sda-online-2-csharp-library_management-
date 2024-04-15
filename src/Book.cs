public class Book : LibraryItem
{
    private string _title;

    public Book(string title, DateTime createdDate) : base(createdDate)
    {
        _title = title;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string title)
    {
        _title = title;
    }

}