using Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs.Notification;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    public MessageController()
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> Push(
        [FromBody] Message message,
        [FromServices] IHubContext<MessageHub, IMessageClient> hubContext)
    {
        await hubContext.Clients.All.Send(message);
        return Ok();
    }
}
