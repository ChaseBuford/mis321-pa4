using System.Collections.Generic;
using PA4.Models;

namespace PA4.Interfaces
{
    public interface ISongUtilities
    {
        public List<Song> playlist { get; set; }
         public void AddSong();
         public void DeleteSong();
         public void EditSong(Song song);
         public void PrintPlaylist();
    }
}