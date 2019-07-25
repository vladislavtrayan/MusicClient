using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Core;
using Core.Interfaces;
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

        public Album GetAlbum(string albumName)
        {
            throw new Exception("No realization");
        }
        
        public PlayList GetPlayList(string playListName)
        {
            throw new Exception("No realization");
        }
        
        public PlayList GetPlayListDeJaVu()
        {
            var playListOfTheDay = Authorize().GetPlaylistDejaVu();
            var playList = new PlayList();
            foreach (var track in playListOfTheDay.Tracks)
            {
                var artists = new List<Artist>();
                foreach (var oArtist in track.Artists)
                {
                    artists.Add(new Artist {Name = oArtist.Name});
                }
                playList.Music.Add(new TrackBuilder().SetTitle(track.Title).SetArtist(artists).Build());
            }

            playList.Title = playListOfTheDay.Title;
            playList.Author = playListOfTheDay.Owner.Name;
            return playList;
        }
        
        public PlayList GetPlayOfTheDay()
        {
            var playListOfTheDay = Authorize().GetPlaylistOfDay();
            var playList = new PlayList();
            foreach (var track in playListOfTheDay.Tracks)
            {
                var artists = new List<Artist>();
                foreach (var oArtist in track.Artists)
                {
                    artists.Add(new Artist {Name = oArtist.Name});
                }
                playList.Music.Add(new TrackBuilder().SetTitle(track.Title).SetArtist(artists).Build());
            }

            playList.Title = playListOfTheDay.Title;
            playList.Author = playListOfTheDay.Owner.Name;
            return playList;
        }

        private YandexTrack SearchTrack(string trackName,int page)
        {
            return Authorize().SearchTrack(trackName,page).First();
        }
        
    }
}    