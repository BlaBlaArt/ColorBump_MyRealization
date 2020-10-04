using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pandoragame
{
    public class StartGameScript : MonoBehaviour
    {
        public Canvas MyCanvas;

        public void StartGame()
        {
            MyCanvas.enabled = false;
           // Debug.Log("hello");
            GameControllerScript.StartGame();
        }
    }
}
