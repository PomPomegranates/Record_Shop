namespace Frontend.Components.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";
        public int Year_released { get; set; }
        public List<string> Songs { get; set; } = new List<string>();

        public override string ToString()
        {
            string superSong = "";
            foreach (var song in Songs) {
                superSong += $"{song}, "; 
            }

            return Title + Artist + Year_released.ToString() + superSong;
           
        }

    }
}
