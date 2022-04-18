using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PA4.Database;
using PA4.Interfaces;
using PA4.Models;
using Microsoft.AspNetCore.Cors;
using PA4.Utilities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class songController : ControllerBase
    {
        // GET: api/song
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            IReadSongs readObject = new ReadSong();
            return readObject.GetAll();
        }

        // GET: api/song/5
            // [HttpGet("{id}", Name = "Get")]
            // public Song Get(int id)
            // {
            //     IReadSongs readObject = new ReadSong();
            //     return readObject.GetAll(id);
            // }

        // POST: api/song
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            Console.WriteLine(value.SongTitle);
            ICreateSongs createObject = new CreateSong();
            createObject.Create(value);
            // ISongUtilities addObject = new SongUtilDatabase();
            // addObject.AddSong(value);
        }

        // PUT: api/song/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Song song)
        {
            System.Console.WriteLine("made it to put");
            ISongUtilities updateObject = new SongUtilDatabase();
            updateObject.EditSong(song);
        }

        // DELETE: api/song/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // System.Console.WriteLine("MADE IT");
            IDeleteSongs deleteObject = new SongUtilDatabase();
            deleteObject.Delete(id);
        }
    }
}
