namespace messages_crud.Models
{
    public class MessageViewModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
    }
}
