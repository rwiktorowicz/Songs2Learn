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
    public class HomeController : AsyncController
    {
        private ArtistDbContext db = new ArtistDbContext();

        public ActionResult Index()
        {
            //SpotifyWebAPIClass test = new SpotifyWebAPIClass();

            var Track = (from t in db.Tracks
                         orderby Guid.NewGuid()
                         select t).FirstOrDefault();

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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}