using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pandoragame
{

    public class NextLevelscript : MonoBehaviour
    {


        public void NextLevelLoad()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(Levels.Level_0.ToString());

    }
    }
}
