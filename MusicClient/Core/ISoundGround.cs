using Core.Models;

namespace Core
{
    public interface ISoundGround
    {
        
        Track GetTrack();
        Track GetTrack(string trackName);
        Album GetAlbum();
        PlayList GetPlayList();
    }
}