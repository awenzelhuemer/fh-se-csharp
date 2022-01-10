using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Wpf.ViewModels
{
    public class MainViewModel
    {
        #region Private Fields

        private static readonly MediaLibrary mediaLibrary = new();
        private ICommand playCmd;

        #endregion

        #region Public Constructors

        public MainViewModel()
        {
            mediaLibrary.CurrentSong += OnSongPlayed;
            foreach (var song in mediaLibrary.GetAllSongs())
            {
                Songs.Add(new SongViewModel(song));
            }
        }

        private void OnSongPlayed(Song song)
        {
            Console.WriteLine(song);
        }

        #endregion

        #region Public Properties

        public SongViewModel CurrentSong { get; set; }

        public ColorList Colors { get; } = new ColorList();

        public ICommand PlayCmd
        {
            get
            {
                if (playCmd == null)
                {
                    playCmd = new RelayCommand(param => ExecutePlayCmd(param), param => CanExecutePlayCmd(param));
                }
                return playCmd;
            }
        }

        public ObservableCollection<SongViewModel> Songs { get; init; } = new();

        #endregion

        #region Private Methods

        private bool CanExecutePlayCmd(object param)
        {
            return CurrentSong != null;
        }

        private void ExecutePlayCmd(object cmd)
        {
            mediaLibrary.PlaySong(CurrentSong.Song);
        }

        #endregion
    }
}