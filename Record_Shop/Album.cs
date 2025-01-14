namespace Record_Shop
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Song> Songs { get; set; }

    }
}
