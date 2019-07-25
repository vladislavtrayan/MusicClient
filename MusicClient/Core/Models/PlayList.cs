using System.Collections.Generic;
using Core.Interfaces;

namespace Core.Models
{
    public class PlayList : ITrackCollection
    {
        public PlayList()
        {
            Music = new List<Track>();
        }
        public List<Track> Music { get; set; }
        public string Title { get; set; }
        public string Author { get; set; } 
    }
}