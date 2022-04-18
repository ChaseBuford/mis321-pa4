using System;
using System.IO;
using System.Collections.Generic;
using PA4.Interfaces;
using PA4.Models;

namespace PA4.FileHandleing
{
    public class ReadFromFile : IReadSongs
    {
        public List<Song> GetAll() { // read in songs from songs.txt file to songs list
            List<Song> songs = new List<Song>();
            StreamReader inFile = null;

            try { // try opening songs.txt
                inFile = new StreamReader("songs.txt");
            } 
            catch { // if songs.txt doesn't exist, display error message and continue
                Console.Clear();
                Console.WriteLine("The songs.txt file does not exist yet. Add songs to the playlist to create the file.\nPress any key to continue to the menu.");
                Console.ReadKey();
                return songs;
            }
            string line = inFile.ReadLine();

            while (line != null) {
                string[] temp = line.Split("#");
                songs.Add(new Song(){SongID = int.Parse(temp[0]), SongTitle = temp[1], SongTimestamp = DateTime.Parse(temp[2]), Favorite = temp[3]});
                line = inFile.ReadLine();
            }

            inFile.Close();
            return songs;
        }

        public Song GetOne(int id)
        {
            List<Song> songs = new List<Song>();
            StreamReader inFile = null;

            try { // try opening songs.txt
                inFile = new StreamReader("songs.txt");
            } 
            catch { // if songs.txt doesn't exist, display error message and continue
                Console.Clear();
                Console.WriteLine("The songs.txt file does not exist yet. Add songs to the playlist to create the file.\nPress any key to continue to the menu.");
                Console.ReadKey();
                return new Song();
            }
            string line = inFile.ReadLine();

            while (line != null) {
                string[] temp = line.Split("#");
                songs.Add(new Song(){SongID = int.Parse(temp[0]), SongTitle = temp[1], SongTimestamp = DateTime.Parse(temp[2]), Favorite = temp[3]});
                line = inFile.ReadLine();
            }

            inFile.Close();

            return songs.Find(x => x.SongID == id); 
        }
    }
}