using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songs2Learn.DAL;
using Songs2Learn.Models;
using System.Threading.Tasks;
using Songs2Learn.Classes;

namespace Songs2Learn.Controllers
{
    public class HomeController : Controller
    {
        private ArtistDbContext db = new ArtistDbContext();
        private Random rand = new Random();

        public ActionResult Index()
        {
            //Initial selection of random Artist.
            int artistid = rand.Next(1, db.Artists.Count() + 1);
            Artist Artist = (from a in db.Artists
                          where a.ID == artistid
                          select a).FirstOrDefault();

            //If the artist does not have any tracks in the database, continue selecting a random artist until you get one that does.
            while (Artist.Tracks.Count == 0)
            {
                artistid = rand.Next(1, db.Artists.Count() + 1);
                Artist = (from a in db.Artists
                          where a.ID == artistid
                          select a).FirstOrDefault();
            }

            //Make a random track selection from what the artist has in the database.
            int trackindex = rand.Next(0, Artist.Tracks.Count);
            Track Track = Artist.Tracks.ElementAt(trackindex);
                          
            //Pulling information from Spotify.
            SpotifyTrackData SpotifyTrackData = new SpotifyTrackData(Track.Artist.Name, Track.Name);

            ViewBag.AlbumArtURL = SpotifyTrackData.AlbumArtURL;
            ViewBag.AlbumName = SpotifyTrackData.AlbumName;
            ViewBag.SpotifyURL = SpotifyTrackData.SpotifyURL;
            ViewBag.AudioURL = SpotifyTrackData.AudioSampleURL;

            ViewBag.YoutubeURL = "http://www.youtube.com/results?search_query=" + Track.Artist.Name + " " + Track.Name;
            ViewBag.SongsterrURL = String.Format("http://www.songsterr.com/a/wa/bestMatchForQueryString?s={0}&a={1}", Track.Name, Track.Artist.Name);

            return View(Track);

        }


        public ActionResult About()
        {
            ViewBag.Message = "Songs2Learn";

            return View();
        }

    }
}