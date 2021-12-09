namespace QueueChat.Models
{
    public class CreateMessageEvent
    {
        public string Name { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
