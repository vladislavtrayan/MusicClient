using System.Collections.Generic;

namespace Core.Models
{
    public class PlayList : ITrackCollection
    {
        public List<Track> Music { get; set; }
        public string Title { get; set; }
        public string Author { get; set; } 
    }
}