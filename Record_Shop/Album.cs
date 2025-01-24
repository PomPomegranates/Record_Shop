namespace Record_Shop
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  string Artist { get; set; }
        public int Year_released { get; set; }
        public List<string> Songs { get; set; }

    }
}
