using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;

namespace Songs2Learn.Classes
{
    public class SpotifyTrackData
    {
        public string AlbumArtURL { get; private set; }
        public string AlbumName { get; private set; }
        public string SpotifyURL { get; private set; }
        public string AudioSampleURL { get; set; }

        public SpotifyTrackData(string Artist, string Track)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString(String.Format("https://api.spotify.com/v1/search?q=artist:{0} track:{1}&type=track", Artist, Track));
            JObject JsonObject = JObject.Parse(json);

            if (JsonObject["tracks"]["items"].ToList().Count == 0) {
                AlbumArtURL = VirtualPathUtility.ToAbsolute("~/Images/noalbum.jpg");
                AlbumName = "Unknown Album";
                SpotifyURL = "http://www.spotify.com";
                AudioSampleURL = "";
            }
            else
            {
                AlbumArtURL = (string)JsonObject["tracks"]["items"][0]["album"]["images"][0]["url"];
                AlbumName = (string)JsonObject["tracks"]["items"][0]["album"]["name"];
                SpotifyURL = (string)JsonObject["tracks"]["items"][0]["uri"];
                AudioSampleURL = (string)JsonObject["tracks"]["items"][0]["preview_url"];
            }


            

        }

    }
}
