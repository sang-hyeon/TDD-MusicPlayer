using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace TDD_MusicPlayer.UnitTest.Tools
{
    public static class Generate
    {
        public static IEnumerable<Song> Songs(int length = 3)
        {
            for (int i = 0; i < length; i++)
            {
                yield return new Song("a" + i, "b" + i);
            }
        }

        public static Song[] SongsAsArray(int length = 3)
        {
            return Songs(length).ToArray();
        }

        public static List<Song> SongsAsList(int length  = 3)
        {
            return Songs(length).ToList();
        }

        public static ImmutableArray<Song> SongsAsImmutable(int length = 3)
        {
            return Songs(length).ToImmutableArray();
        }

        public static CompactDisk CD(int length = 3)
        {
            IEnumerable<Song> songs = Songs(length);
            return CompactDisk.Write(songs);
        }
    }
}
