using FluentAssertions;
using TDD_MusicPlayer.UnitTest.Tools;
using Xunit;

namespace TDD_MusicPlayer.UnitTest
{
    public class CdPlayerTests
    {
        #region insert
        [Fact]
        public void insert_cd_into_cd_player()
        {
            // Arrange
            CompactDisk cd = Generate.CD();
            var sut = new CdPlayer();

            // Act
            sut.Insert(cd);

            // Assert
            sut.HasCD.Should().BeTrue();
            sut.CurrentTrack.Should().Be(1);
        }

        [Fact]
        public void cannot_insert_cd_into_cd_player_that_has_already_one()
        {
            // Arrange
            CompactDisk cd = Generate.CD();
            var sut = new CdPlayer();
            sut.Insert(cd);

            // Act
            var inserting = () => sut.Insert(cd);

            // Assert
            inserting.Should().Throw<AlreadyInsertedException>();
        }
        #endregion

        #region remove
        [Fact]
        public void remove_cd_from_cd_player_that_has_cd()
        {
            var cd = Generate.CD();
            var sut = new CdPlayer();
            sut.Insert(cd);

            sut.Remove();

            sut.HasCD.Should().BeFalse();
            sut.CurrentTrack.Should().Be(0);
        }

        [Fact]
        public void remove_cd_from_the_playing_cd_player()
        {
            CompactDisk cd = Generate.CD();
            var sut = new CdPlayer();
            sut.Insert(cd);
            sut.Play();

            sut.Remove();

            sut.HasCD.Should().BeFalse();
            sut.CurrentTrack.Should().Be(0);
            sut.IsPlaying.Should().BeFalse();
        }
        #endregion

        #region play
        [Fact]
        public void play_music_when_cd_player_is_not_playing()
        {
            CompactDisk cd = Generate.CD();
            var expectedSong = cd.GetTrack(1);
            var sut = new CdPlayer();
            sut.Insert(cd);

            sut.Play();

            sut.IsPlaying.Should().BeTrue();
        }
        #endregion

        #region stop
        [Fact]
        public void stop_music_when_cd_player_is_playing()
        {
            CompactDisk cd = Generate.CD();
            var sut = new CdPlayer();
            sut.Insert(cd);
            sut.Play();

            sut.Stop();

            sut.IsPlaying.Should().BeFalse();
        }
        #endregion

        #region next
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(10, 1, 2)]
        [InlineData(10, 2, 3)]
        [InlineData(10, 3, 4)]
        [InlineData(100, 55, 56)]
        [InlineData(100, 99, 100)]
        public void play_next_music_when_cd_player_is_playing(
                                int numberOfSongs, int currentTrack, int expectedTrack)
        {
            CompactDisk cd = Generate.CD(numberOfSongs);
            var sut = new CdPlayer();
            sut.Insert(cd);
            NextSequentially(currentTrack - 1, sut);
            sut.Play();

            sut.Next();

            sut.CurrentTrack.Should().Be(expectedTrack);
            sut.IsPlaying.Should().BeTrue();
        }


        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(10, 1, 2)]
        [InlineData(10, 2, 3)]
        [InlineData(10, 3, 4)]
        [InlineData(100, 55, 56)]
        public void move_to_next_track_when_cd_player_is_not_playing(
                                int numberOfSongs, int currentTrack, int expectedTrack)
        {
            CompactDisk cd = Generate.CD(numberOfSongs);
            var sut = new CdPlayer();
            sut.Insert(cd);
            NextSequentially(currentTrack - 1, sut);

            sut.Next();

            sut.CurrentTrack.Should().Be(expectedTrack);
            sut.IsPlaying.Should().BeFalse();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(77)]
        [InlineData(100)]
        public void play_first_music_via_next_when_cd_player_is_playing_last_music(
                                    int numberOfSongs)
        {
            CompactDisk cd = Generate.CD(numberOfSongs);
            var sut = new CdPlayer();
            sut.Insert(cd);
            NextSequentially(numberOfSongs - 1, sut);
            sut.Play();

            sut.Next();

            sut.CurrentTrack.Should().Be(1);
            sut.IsPlaying.Should().BeTrue();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(77)]
        [InlineData(100)]
        public void move_to_first_track_via_next_when_last_track(
                                    int numberOfSongs)
        {
            CompactDisk cd = Generate.CD(numberOfSongs);
            var sut = new CdPlayer();
            sut.Insert(cd);
            NextSequentially(numberOfSongs - 1, sut);

            sut.Next();

            sut.CurrentTrack.Should().Be(1);
            sut.IsPlaying.Should().BeFalse();
        }
        #endregion

        private static void NextSequentially(int currentTrack, CdPlayer player)
        {
            for (int i = 0; i < currentTrack; i++)
            {
                player.Next();
            }
        }
    }
}
