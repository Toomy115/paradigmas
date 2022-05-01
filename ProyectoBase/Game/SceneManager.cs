using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SceneManager
    {
        private static readonly SceneManager instance = new SceneManager();
        private int _currentScene = 0;

        public static SceneManager Instance
        {
            get
            {
                return instance;
            }
        }
        public int GetCurrentScene
        {
            get { return _currentScene; }
        }

        public int SetCurrentScene
        {
            set { _currentScene = value; }
        }

        public void Update()
        {
            switch (_currentScene)
            {
                case 0: //MENU PRINCIPAL
                    Draw("Textures/Titles/Main_Title.png");
                    if (Engine.GetKey(Keys.SPACE))
                    {
                        _currentScene = 1;
                    }
                    break;
                case 1:

                    /*if(_enemiesDestroyed == _enemiesToDestroy)
                    {
                        _currentScene = 2;
                    }*/
                    break;
                case 2://VICTORY                    
                    Draw("Textures/Titles/Level_Complete.png");
                    if (Engine.GetKey(Keys.SPACE))
                    {
                        //_enemiesDestroyed = 0;
                        //_enemiesToDestroy += _enemiesNextLevel;
                        _currentScene = 1;
                    }
                    break;
                case 3:
                    Draw("Textures/Titles/Game_Over.png");
                    if (Engine.GetKey(Keys.SPACE))
                    {
                        //_enemiesDestroyed = 0;
                        
                        _currentScene = 1;
                    }
                    break;
                default:
                    Draw("Textures/Titles/Main_Title.png");
                    if (Engine.GetKey(Keys.SPACE))
                    {
                        _currentScene = 1;
                    }
                    break;                   
            }
            
        }

        private void Draw(string path)
        {
            Engine.Clear();
            Engine.Draw("Textures/Background/background.png", 0, 0, 1f, 1f);
            Engine.Draw(path, 0, 0, 1f, 1f);
            Engine.Show();
        }

    }
}
