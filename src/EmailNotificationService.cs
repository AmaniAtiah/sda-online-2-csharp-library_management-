public class EmailNotificationService : INotificationService {
    public void SendNotificationOnSuccess(string message)
    {
        Console.WriteLine($"Email Notification: {message}");
    } 
    public void SendNotificationOnFailure(string errorMessage)
    {
        Console.WriteLine($"Email Notification: {errorMessage}");
    }
    
}