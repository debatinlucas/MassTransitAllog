using MassTransit;
using MassTransitAllog.Shared;
using System.Text.Json;

namespace MassTransitAllog.Consumer;

public class NotificationCreatedConsumer : IConsumer<INotificationCreated>
{
    public async Task Consume(ConsumeContext<INotificationCreated> context)
    {
        var serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });

        Console.WriteLine($"Producer: {serializedMessage}");
    }
}