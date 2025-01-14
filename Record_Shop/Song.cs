namespace Record_Shop
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Artist> Artists { get; set; }
        public int Seconds { get; set; }
    }
}
