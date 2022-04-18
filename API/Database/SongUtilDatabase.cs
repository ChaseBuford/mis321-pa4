using System;
using System.IO;
using System.Collections.Generic;
using PA4.Models;
using PA4.Interfaces;
using PA4.Database;
using MySql.Data.MySqlClient;

namespace PA4.Utilities
{
    public class SongUtilDatabase : ISongUtilities, IDeleteSongs
    {
        public List<Song> playlist { get; set; }
         public void PrintPlaylist()    // display all items in the playlist to the console
         {
            Console.Clear();
            List<Song> songs = new ReadSong().GetAll();
            foreach (Song song in songs)
            {
                Console.WriteLine("ID: " + song.SongID + "\n  Title: " + song.SongTitle + "\n  Date Added: " + song.SongTimestamp);
            }
        }

        public void AddSong() { // allow the user to add a new song to the playlist
            Song song = new Song();
            playlist.Add(new Song(){SongTitle = PromptSongDetails(), SongTimestamp = DateTime.Now, Favorite = "n"});
        }

        public string PromptSongDetails() { // Ask user for title of the song to add
            Console.Clear();
            string userInput;
            Console.WriteLine("What is the title of your song?");
            userInput = Console.ReadLine();
            CreateSong.AddSong(new Song(){SongTitle = userInput, SongTimestamp = DateTime.Now, Favorite = "false"});
            return userInput;
        }

        public void DeleteSong() { // remove a song from the playlist given the SongID
            Console.Clear();
            Song allSongs = new Song();
            // bool delete = false;
            int userInput;
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            List<Song> songs = new ReadSong().GetAll();
            foreach (Song song in songs)
            {
                Console.WriteLine("ID: " + song.SongID + "\n  Title: " + song.SongTitle + "\n  Date Added: " + song.SongTimestamp);
            }

            Console.WriteLine("\nWhat is the songID?");
            userInput = int.Parse(Console.ReadLine());

            string stm = @"DELETE FROM songs WHERE id = " + userInput + ";";

            // string stm1 = @"UPDATE songs set title = '" + delete + "' WHERE id = " + userInput + ";";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
            Console.Clear();
            Console.WriteLine("Song has been removed.");
        }

        public int PromptSongToDelete(List<Song> playlist) { // ask the user the ID of the song they want to delete
            
            string userInput;
            
            do {

                Console.Clear();
                PrintPlaylist();
                Console.WriteLine("What is the ID of the song you want to delete?");
                userInput = Console.ReadLine();

            } while (!CheckValidInput(userInput)); // ID entered must be an integer
            
            return int.Parse(userInput);
        }

        public bool CheckValidIndex(int index) {
            if (index == -1) { // if playlist.FindAt returns -1, the ID was not found in the list
                Console.WriteLine("\nID does not exist in the current playlist. Press any key to continue");
                Console.ReadKey();
                return false;
            }
            return true;
        }

        public bool CheckValidInput(string userInput) { // check to see if user's input is an integer
            int parsedInput;

            if (!int.TryParse(userInput, out parsedInput)) {
                Console.WriteLine("Invalid input. Try again.");
                Console.ReadKey();
                return false;
            }

            return true;
        }

        public void EditSong(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            // List<Song> songs = new ReadSong().GetAll();
            // foreach (Song song in songs)
            // {
            //     Console.WriteLine("ID: " + song.SongID + "\n  Title: " + song.SongTitle + "\n  Date Added: " + song.SongTimestamp);
            // }

            // Console.WriteLine("\nWhat is the song id?");
            // userInput = int.Parse(Console.ReadLine());
            // // Console.WriteLine("What is the new title?");
            // newTitle = Console.ReadLine();

            string stm = @"UPDATE songs set title = '" + song.SongTitle + ", date_time = " + song.SongTimestamp + ", favorties = " + song.Favorite +   "WHERE id = " + song.SongID + ";";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
            Console.Clear();
            Console.WriteLine("Song has been altered.");
        }

        public void Delete(int id)
        {
           ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM songs WHERE id = " + id + ";";

            // string stm1 = @"UPDATE songs set title = '" + delete + "' WHERE id = " + userInput + ";";

            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Song has been removed.");

        }

    }
}