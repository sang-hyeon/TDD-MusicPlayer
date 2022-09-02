namespace TDD_MusicPlayer
{
    public record Song
    {
        public string Title { get; }
        public string Artist { get; }

        public Song(string artist, string title)
        {
            this.Artist = artist;
            this.Title = title;
        }
    }
}
