using MassTransit;
using MassTransitAllog.Producer.Models;
using MassTransitAllog.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitAllog.Producer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    public readonly IPublishEndpoint publishEndpoint;

    public NotificationController(IPublishEndpoint publishEndpoint)
    {
        this.publishEndpoint = publishEndpoint;
    }

    [HttpPost]
    public async Task<IActionResult> Notify(NotificationDto notificationDto)
    {
        await publishEndpoint.Publish<INotificationCreated>(new
        {
            notificationDto.Date,
            notificationDto.Message,
            notificationDto.Author
        });

        return Ok();
    }
}