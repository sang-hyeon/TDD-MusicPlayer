using System.Collections.Generic;
using System.Collections.Immutable;

namespace TDD_MusicPlayer
{
    public class CompactDisk
    {
        private readonly ImmutableArray<Song> _songs;

        public int NumberOfSongs
            => this._songs.Length;

        private CompactDisk(ImmutableArray<Song> songs)
        {
            this._songs = songs;
        }

        public Song GetTrack(int trackNumber)
        {
            if (1 <= trackNumber && trackNumber <= this._songs.Length)
                return this._songs[trackNumber - 1];
            else
                throw new TrackNumberOutOfRangeException();
        }

        public static CompactDisk Write(IEnumerable<Song> songs)
        {
            ImmutableArray<Song> immutableSongs = songs.ToImmutableArray();

            return new CompactDisk(immutableSongs);
        }
    }
}
