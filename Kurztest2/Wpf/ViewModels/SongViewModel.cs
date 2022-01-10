namespace Wpf.ViewModels
{
    public class SongViewModel
    {
        private readonly Song song;

        public SongViewModel(Song song)
        {
            this.song = song;
        }

        public Song Song
        {
            get
            {
                return song;
            }
        }

        public string Name
        {
            get { return song.Name; }
        }

    }
}
