using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QueueChat.DataAccess;
using QueueChat.Models;

namespace QueueChat.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext dbContext;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        [BindProperty]
        public ChatRoom NewChatRoom { get; set; } = new();
        public IEnumerable<ChatRoom> ChatRooms { get; set; } = Array.Empty<ChatRoom>();

        public async Task OnGet()
        {
            ChatRooms = await dbContext.ChatRooms.Include(r => r.Members).ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await dbContext.ChatRooms.AddAsync(new ChatRoom { Name = NewChatRoom.Name });

            await dbContext.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}