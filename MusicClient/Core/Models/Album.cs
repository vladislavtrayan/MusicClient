using System.Collections.Generic;

namespace Core.Models
{
    public class Album : ITrackCollection
    {
        public List<Track> Music { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        
    }
}