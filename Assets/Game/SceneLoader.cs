using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using LoopBytes.System;

namespace Game
{
    public class SceneLoader : Singleton<SceneLoader>  {
     
        public void LoadMenu()
        {
            SceneManager.LoadSceneAsync("Menu");
        }

        public void LoadMain()
        {
            SceneManager.LoadSceneAsync("Main");
        }

        public void LoadSettings()
        {
           

            SceneManager.LoadSceneAsync("Settings");
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void ResetScence()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
