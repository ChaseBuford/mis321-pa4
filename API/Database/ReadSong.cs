using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PA4.Interfaces;
using PA4.Models;

namespace PA4.Database
{
    public class ReadSong : IReadSongs
    {
        public List<Song> GetAll()
        {
            List<Song> allSongs = new List<Song>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM songs ORDER BY date_added asc";
            using var cmd = new MySqlCommand(stm, con);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                allSongs.Add(new Song(){SongID = rdr.GetInt32(0), SongTitle = rdr.GetString(1), SongTimestamp = rdr.GetDateTime(2), Favorite = rdr.GetString(3)});
            }
            return allSongs;
        }

        public Song GetOne(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}