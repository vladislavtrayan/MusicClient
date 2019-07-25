using Core.Models;

namespace Core.Interfaces
{
    public interface ISoundGround
    {
        
        Track GetTrack(string trackName);
        Album GetAlbum(string albumName);
        PlayList GetPlayList(string playListName);
    }
}