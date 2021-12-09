using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueueChat.DataAccess;
using QueueChat.Models;

namespace QueueChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly ILogger<QueueController> logger;
        private readonly ApplicationDbContext applicationDbContext;

        public QueueController(ILogger<QueueController> logger, ApplicationDbContext applicationDbContext)
        {
            this.logger = logger;
            this.applicationDbContext = applicationDbContext;
        }

        [HttpPost("Messages")]
        public async Task<IActionResult> PublishMessage(CreateMessageEvent createMessageEvent)
        {
            logger.LogInformation("Received create message event - event name: {eventName}, room name: {roomName}", createMessageEvent.Name, createMessageEvent.RoomName);

            var room = await applicationDbContext.ChatRooms.FirstAsync(c => c.Name == createMessageEvent.RoomName);

            room.Members.Add(new ChatMember { Name = createMessageEvent.Name, Country = createMessageEvent.Country });

            await applicationDbContext.SaveChangesAsync();

            logger.LogInformation("Created new chat member: {@memberId}", room.Members.First(m => m.Name == createMessageEvent.Name).Id);

            return Ok();
        }
    }
}
