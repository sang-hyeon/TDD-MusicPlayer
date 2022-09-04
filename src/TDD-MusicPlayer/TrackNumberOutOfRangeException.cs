using System;

namespace TDD_MusicPlayer
{
    public class TrackNumberOutOfRangeException : Exception
    {
        private static string MESSAGE = "트랙 넘버가 범위를 벗어났습니다.";
        public TrackNumberOutOfRangeException() : base(MESSAGE)
        {
        }
    }
}