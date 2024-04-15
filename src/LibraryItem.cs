public class LibraryItem
{
    private Guid Id;
    private DateTime CreatedDate;

    public LibraryItem(DateTime createdDate)
    {
        Id = Guid.NewGuid();
        CreatedDate = createdDate;
    }

    public Guid GetId()
    {
        return Id;
    }

    public void SetId(Guid id)
    {
        Id = id;
    }


    public DateTime GetCreatedDate()
    {
        return CreatedDate;
    }
    public void SetCreatedDate(DateTime createdDate)
    {
        CreatedDate = createdDate;
    }


}