namespace QueueChat.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ChatMember> Members {get; set;} = new List<ChatMember>();
    }
}
