namespace DialogsDemo.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateCompleted { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
