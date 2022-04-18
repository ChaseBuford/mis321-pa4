using System;
using System.Collections.Generic;
using System.IO;
using PA4.Interfaces;
using PA4.Models;

namespace PA4.FileHandleing
{
    public class WriteToFile : ICreateSongs
    {
        public void Create(Song song)
        {
            StreamWriter outFile = new StreamWriter("songs.txt", true);

            outFile.WriteLine("{0}#{1}#{2}#{3}", song.SongID, song.SongTitle, DateTime.Now, "n");

            outFile.Close();
        }

         public static void WriteAllToFile(List<Song> Playlist) { // write songs in playlist to songs.txt
            StreamWriter outFile = new StreamWriter("songs.txt");

            foreach (Song song in Playlist) {
                outFile.WriteLine("{0}#{1}#{2}#{3}", song.SongID, song.SongTitle, song.SongTimestamp, "n");
            }

            outFile.Close();
        } 
    }
}