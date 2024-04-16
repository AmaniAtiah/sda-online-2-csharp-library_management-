public class Library
{
    private List<Book> _books;
    private List<User> _users;
    public Library()
    {
        _books = new List<Book>();
        _users = new List<User>();
    }

    private INotificationService _notificationService;

    public Library(INotificationService _notificationService)
    {
        this._notificationService = _notificationService;
    }

    public INotificationService GetNotificationService()
    {
        return _notificationService;
    }

    public void SetNotificationService(INotificationService _notificationService)
    {
        this._notificationService = _notificationService;
    }

    public void DisplayBooks(List<Book> books)
    {
        foreach (Book book in books)
        {
            Console.WriteLine(book.GetTitle());

        }
    }


    public void DisplayUsers(List<User> users)
    {
        foreach (User user in users)
        {
            Console.WriteLine(user.GetName());
        }
    }

    public List<Book> GetBooks(int pageNumber, int pageSize)
    {
        List<Book> books = _books.OrderBy(book => book.GetCreatedDate())
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();

        DisplayBooks(books);


        return books;
    }



    public List<User> GetUsers(int pageNumber, int pageSize)
    {
        List<User> users = _users.OrderBy(user => user.GetCreatedDate())
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

        DisplayUsers(users);

        return users;

    }

    public List<Book> FindBooksByTitle(string title)
    {
        List<Book> books = _books.Where(book => book.GetTitle().Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplayBooks(books);
        return books;

    }

    public List<User> FindUsersByName(string name)
    {
        List<User> users = _users.Where(user => user.GetName().Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplayUsers(users);
        return users;
    }

    public void AddBook(Book book)
    {
        try
        {
            bool bookExists = _books.Any(b => b.GetTitle() == book.GetTitle());
            if (bookExists)
            {

                _notificationService.SendNotificationOnFailure($"A book titled '{book.GetTitle()}' already exists in the Library.");
            }
            else
            {
                _books.Add(book);
                _notificationService.SendNotificationOnSuccess($"A new book titled '{book.GetTitle()}' has been successfully added to the Library.");


            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");

        }


    }

    public void AddUser(User user)
    {
        try {
            bool userExists = _users.Any(u => u.GetName() == user.GetName());
            if (userExists)
            {

                _notificationService.SendNotificationOnFailure($"A user named '{user.GetName()}' already exists in the Library.");
            }
            else
            {
                _users.Add(user);
                _notificationService.SendNotificationOnSuccess($"A new user named '{user.GetName()}' has been successfully added to the Library.");


            }
        } catch (Exception e){
            Console.WriteLine($"{e.Message}");
        }
    }

    public void RemoveBook(Guid id)
    {
        try {
        Book book = _books.FirstOrDefault(book => book.GetId() == id);

        if (book != null)
        {
            _books.Remove(book);
            _notificationService.SendNotificationOnSuccess($"A book titled '{book.GetTitle()}' has been successfully removed from the Library.");

        }
        else
        {
            _notificationService.SendNotificationOnFailure($"A book titled '{book.GetTitle()}' does not exist in the Library.");  
        }
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");
        }

    }


    public void RemoveUser(Guid id)
    {
        try {
        User user = _users.FirstOrDefault(book => book.GetId() == id);
        if (user != null)
        {
            _users.Remove(user);
            _notificationService.SendNotificationOnSuccess($"A user named '{user.GetName()}' has been successfully removed from the Library.");
        }
        else
        {
            _notificationService.SendNotificationOnFailure($"A user named '{user.GetName()}' does not exist in the Library.");
        }
        } catch (Exception e) {
            Console.WriteLine($"{e.Message}");
        }

    }



}


