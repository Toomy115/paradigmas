using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Game
{
    class MusicController
    {
        private string _filePath = "Textures/Music/";
        private string _musicFile = "Music.wav";
        private string _path;

        public MusicController()
        {
            _path = _filePath + _musicFile;
            SoundPlayer soundPlayer = new SoundPlayer(_path);
            soundPlayer.PlayLooping();
        }
        public void Update()
        {

        }
    }
}
