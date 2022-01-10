using System;
using System.Collections.Generic;

namespace Wpf
{
    public class MediaLibrary
    {
        public event Action<Song> CurrentSong;

        public ICollection<Song> GetAllSongs()
        {
            return new List<Song>() {
                new Song { Name = "Song 1" },
                new Song { Name = "Song 2" }
            };
        }

        public void PlaySong(Song song)
        {
            CurrentSong?.Invoke(song);
            // plays the song
        }
    }
}
