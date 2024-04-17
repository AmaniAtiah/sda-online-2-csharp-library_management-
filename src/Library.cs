public class Library
{
    private List<Book> _books;
    private List<User> _users;
    private INotificationService _notificationService;



    public Library(INotificationService notificationService)
    {
        _books = new List<Book>();
        _users = new List<User>();
        _notificationService = notificationService; ;

    }

    public INotificationService NotificationService
    {
        get { return _notificationService; }
        set { _notificationService = value; }

    }


    public void DisplayBooks(List<Book> books)
    {
        foreach (Book book in books)
        {
            Console.WriteLine(book.Title);

        }
    }


    public void DisplayUsers(List<User> users)
    {
        foreach (User user in users)
        {
            Console.WriteLine(user.Name);
        }
    }

    public List<Book> GetBooks(int pageNumber, int pageSize)
    {
        if (_books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return new List<Book>();
        }

        List<Book> books = _books.OrderBy(book => book.CreatedDate)
                     .Skip((pageNumber - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();

        DisplayBooks(books);


        return books;

    }



    public List<User> GetUsers(int pageNumber, int pageSize)
    {
        if (_users.Count == 0)
        {
            Console.WriteLine("No User available.");
            return new List<User>();
        }

        List<User> users = _users.OrderBy(user => user.CreatedDate)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

        DisplayUsers(users);

        return users;


    }

    public List<Book> FindBooksByTitle(string title)
    {
        List<Book> books = _books.Where(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplayBooks(books);
        return books;

    }

    public List<User> FindUsersByName(string name)
    {
        List<User> users = _users.Where(user => user.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        DisplayUsers(users);
        return users;
    }

    public void AddBook(Book book)
    {
        try
        {
            bool bookExists = _books.Any(b => b.Title == book.Title);
            if (bookExists)
            {

                _notificationService.SendNotificationOnFailure($"A book titled '{book.Title}' already exists in the Library.");
            }
            else
            {
                _books.Add(book);
                _notificationService.SendNotificationOnSuccess($"A new book titled '{book.Title}' has been successfully added to the Library.");


            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");

        }


    }

    public void AddUser(User user)
    {
        try
        {
            bool userExists = _users.Any(u => u.Name == user.Name);
            if (userExists)
            {

                _notificationService.SendNotificationOnFailure($"A user named '{user.Name}' already exists in the Library.");
            }
            else
            {
                _users.Add(user);
                _notificationService.SendNotificationOnSuccess($"A new user named '{user.Name}' has been successfully added to the Library.");


            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }

    public void RemoveBook(Guid id)
    {
        try
        {
            Book book = _books.Find(book => book.Id == id);

            if (book != null)
            {
                _books.Remove(book);
                _notificationService.SendNotificationOnSuccess($"A book titled '{book.Title}' has been successfully removed from the Library.");

            }
            else
            {
                _notificationService.SendNotificationOnFailure($"A book titled '{book.Title}' does not exist in the Library.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }

    }


    public void RemoveUser(Guid id)
    {
        try
        {
            User user = _users.Find(user => user.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                _notificationService.SendNotificationOnSuccess($"A user named '{user.Name}' has been successfully removed from the Library.");
            }
            else
            {
                _notificationService.SendNotificationOnFailure($"A user named '{user.Name}' does not exist in the Library.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }

    }



}


