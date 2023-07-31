namespace MassTransitAllog.Shared
{
    public interface INotificationCreated
    {
        DateTime Date { get; }
        string Message { get; }
        string Author { get; }
    }
}
