using FluentAssertions;
using System;
using System.Collections.Generic;
using TDD_MusicPlayer.UnitTest.Tools;
using Xunit;

namespace TDD_MusicPlayer.UnitTest
{
    public class CompactDiskTests
    {
        [Fact]
        public void show_number_of_songs()
        {
            // Arrange
            int expectedNumberOfSongs = 3;
            IEnumerable<Song> songs =
                    Generate.Songs(expectedNumberOfSongs);

            var sut = CompactDisk.Write(songs);


            // Act
            int actualNumberOfSongs = sut.NumberOfSongs;

            // Assert
            actualNumberOfSongs.Should().Be(expectedNumberOfSongs);
        }

        [Theory]
        [InlineData(10, 1)]
        [InlineData(10, 5)]
        [InlineData(10, 7)]
        [InlineData(10, 10)]
        public void get_track_with_given_track_number(
                                 int numberOfLength, int trackNumber)
        {
            Song[] songs = Generate.SongsAsArray(numberOfLength);
            Song expectedSong = songs[trackNumber - 1];
            var sut = CompactDisk.Write(songs);

            Song actualSong = sut.GetTrack(trackNumber);

            actualSong.Should().Be(expectedSong);
        }

        [Theory]
        [InlineData(10, 0)]
        [InlineData(10, -1)]
        [InlineData(10, 11)]
        [InlineData(10, 15)]
        public void cannot_get_track_by_given_track_number_out_of_range(
                              int numberOfLength, int trackNumber)
        {
            Song[] songs = Generate.SongsAsArray(numberOfLength);
            var sut = CompactDisk.Write(songs);

            Action getting = () => sut.GetTrack(trackNumber);

            getting.Should().Throw<TrackNumberOutOfRangeException>();
        }
    }
}
