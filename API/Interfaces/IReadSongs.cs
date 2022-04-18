using System.Collections.Generic;
using PA4.Models;

namespace PA4.Interfaces
{
    public interface IReadSongs
    {
        public List<Song> GetAll();
        public Song GetOne(int id);
         
    }
}