namespace News.DAL.Entities
{
    public class Novelty
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public int Game_id { get; set; }
    }
}
