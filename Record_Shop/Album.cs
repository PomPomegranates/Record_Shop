namespace Record_Shop
{
    public class Album
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>();

    }
}
