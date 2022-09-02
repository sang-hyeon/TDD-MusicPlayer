namespace TDD_MusicPlayer
{
    public record Track : Song
    {
        public int TrackNumber { get; }

        public Track(int trackNumber, Song song)
            : base(song.Artist, song.Title)
        {
            this.TrackNumber = trackNumber;
        }
    }
}
