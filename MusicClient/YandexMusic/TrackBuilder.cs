using System;
using System.Collections.Generic;
using Core;
using Core.Models;

namespace YandexMusic
{
    public class TrackBuilder
    {
        public TrackBuilder()
        {
            Track = new Track();
        }

        private Track Track { get; set; }
        public Track Build()
        {
            return Track;
        }

        public TrackBuilder SetTitle(string name)
        {
            Track.Title = name;
            return this;
        }

        public TrackBuilder SetArtist(IEnumerable<Artist> artists)
        {
            Track.Artists = new List<Artist>();
            foreach (var artist in artists)
            {
                Track.Artists.Add(artist);
            }
            return this;
        }
    }
}