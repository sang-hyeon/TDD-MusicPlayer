namespace TDD_MusicPlayer
{
    public class CdPlayer
    {
        private CompactDisk? _currentCd;

        private Song? _currentSong
            => this._currentCd?.GetTrack(this.CurrentTrack);

        public int CurrentTrack { get; private set; }
        public bool IsPlaying { get; private set; }

        public bool HasCD
            => this._currentCd is not null;

        public CdPlayer()
        {
        }

        public void Insert(CompactDisk cd)
        {
            if (this.HasCD)
                throw new AlreadyInsertedException();
            else
            {
                this._currentCd = cd;
                Reset();
            }
        }

        public void Remove()
        {
            this._currentCd = null;
            Reset();
        }

        public void Play()
        {
            this.IsPlaying = true;
        }

        public void Stop()
        {
            this.IsPlaying = false;
        }

        public void Next()
        {
            if (this._currentCd is null)
                return;

            var nextTrack = this.CurrentTrack;
            nextTrack = nextTrack % this._currentCd.NumberOfSongs;

            this.CurrentTrack = nextTrack + 1;
        }

        private void Reset()
        {
            if (this.HasCD)
                this.CurrentTrack = 1;
            else
                this.CurrentTrack = 0;

            this.IsPlaying = false;
        }
    }
}
