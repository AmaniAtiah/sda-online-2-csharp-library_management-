public class SMSNotificationService: INotificationService {
    public void SendNotificationOnSuccess(string message)
    {
        Console.WriteLine($"SMS Notification: {message}");
    }
    public void SendNotificationOnFailure(string errorMessage)
    {
        Console.WriteLine($"SMS Notification: {errorMessage}");
    }
}