public class LibraryItem
{
    private Guid _id;
    private string _title;
    private DateTime _createdDate;

    public LibraryItem(string title, DateTime? createdDate = null)
    {
        _id = Guid.NewGuid();
        _title = title;
        _createdDate = createdDate ?? DateTime.Now;
    }


    public Guid Id{
        get{return _id; }
        set{ _id = value; }

    }


     public string Title{
        get{return _title; }
        set{ _title = value; }

    }

    public DateTime CreatedDate{
        get{return _createdDate; }
        set{ _createdDate = value; }

    }


}