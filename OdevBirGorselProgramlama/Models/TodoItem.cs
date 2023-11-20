namespace OdevBirGorselProgramlama.Models
{
    public class TodoItem
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public bool Done { get; set; }

        public bool IsSelected { get; set; }

        public DateTime Date { get; set; }

        public string Priority { get; set; }
    }
}
