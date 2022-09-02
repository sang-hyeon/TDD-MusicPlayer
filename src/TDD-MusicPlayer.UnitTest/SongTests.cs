using FluentAssertions;
using Xunit;

namespace TDD_MusicPlayer.UnitTest
{
    public class SongTests
    {
        [Fact]
        public void show_title()
        {
            string expectedTitle = "a";
            var sut = new Song(string.Empty, expectedTitle);

            sut.Title.Should().Be(expectedTitle);
        }

        [Fact]
        public void show_artist()
        {
            string expectedArtist = "a";
            var sut = new Song(expectedArtist, string.Empty);

            sut.Artist.Should().Be(expectedArtist);
        }
    }
}