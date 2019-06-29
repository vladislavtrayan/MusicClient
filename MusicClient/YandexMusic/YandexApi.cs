using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Core;
using Core.Models;
using Yandex.Music.Api;
using Yandex.Music.Api.Models;

namespace YandexMusic
{
    public class YandexApi : ISoundGround
    {

        public char[] UserName { get; set; }
        public char[] Password { get; set; }

        public YandexMusicApi Authorize()
        {
            var api = new YandexMusicApi();
            api.Authorize(new string(UserName), new string(Password));
            return api;
        }

        public Track GetTrack(string trackName)
        {
            var track = SearchTrack(trackName, 0);
            var artists = new List<Artist>();
            foreach (var oArtist in track.Artists)
            {
                artists.Add(new Artist {Name = oArtist.Name});
            }
            return new TrackBuilder().SetTitle(track.Title).SetArtist(artists).Build();
        }


        public Track GetTrack()
        {
            throw new NotImplementedException();
        }

        public Album GetAlbum()
        {
            throw new Exception("No realization");
        }
        
        public PlayList GetPlayList()
        {
            throw new Exception("No realization");
        }
        
        public PlayList GetPlayListDeJaVu()
        {
            throw new Exception("No realization");
        }
        
        public PlayList GetPlayOfTheDay()
        {
            throw new Exception("No realization");
        }

        private YandexTrack SearchTrack(string trackName,int page)
        {
            return Authorize().SearchTrack(trackName,page).First();
        }
        
    }
}    