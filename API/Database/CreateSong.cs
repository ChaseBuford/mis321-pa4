using System;
using PA4.Interfaces;
using PA4.Models;
using MySql.Data.MySqlClient;

namespace PA4.Database
{
    public class CreateSong     :   ICreateSongs
    {
        public static void CreateSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, date_added DATE, favorites TEXT)";
            // string stm = @"DROP TABLE IF EXISTS songs";
            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
        public static void AddSong(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs(title, date_added, favorites) VALUES(@title, @date_added, @favorites)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@date_added", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@favorite", song.Favorite);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void Create(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            song.Favorite = "no";

            string stm = @"INSERT INTO songs(title, date_added) VALUES(@title, @date_added)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@date_added", DateTime.Now);
            cmd.Parameters.AddWithValue("@favorites", song.Favorite);
            //cmd.Parameters.AddWithValue("@deleted", song.Deleted);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}