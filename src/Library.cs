public class Library
{
    private List<Book> _books;
    private List<User> _users;

    public Library()
    {
        _books = new List<Book>();
        _users = new List<User>();
    }

    public void DisplayBooks(List<Book> books)
    {
        foreach (Book book in books)
        {
            Console.WriteLine(book.GetTitle());
            Console.WriteLine(book.GetId());


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
        _books.Add(book);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void RemoveBook(Guid id)
    {
        Book book = _books.FirstOrDefault(book => book.GetId() == id);

        if (book != null)
        {
            _books.Remove(book);
            Console.WriteLine("Book removed successfully.");

        }
        else
        {
            Console.WriteLine("Book not found.");
        }

    }


    public void RemoveUser(Guid id)
    {
        User user = _users.FirstOrDefault(book => book.GetId() == id);
        if (user != null)
        {
            _users.Remove(user);
            Console.WriteLine("User removed successfully.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }

    }



}


