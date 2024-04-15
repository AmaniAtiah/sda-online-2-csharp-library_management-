public class LibraryItem
{
    private Guid _id;
    private string _title;
    private DateTime _createdDate;

    public LibraryItem(string _title, DateTime _createdDate)
    {
        this._id = Guid.NewGuid();
        this._title = _title;
        this._createdDate = _createdDate;
    }



    public Guid GetId()
    {
        return _id;
    }

    public void SetId(Guid _id)
    {
        this._id = _id;
    }

    public DateTime GetCreatedDate()
    {
        return _createdDate;
    }
    public void SetCreatedDate(DateTime _createdDate)
    {
        this._createdDate = _createdDate;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string _title)
    {
        this._title = _title;
    }


}