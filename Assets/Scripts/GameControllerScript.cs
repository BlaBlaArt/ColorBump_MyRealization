using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pandoragame
{
    public enum Colors
    {
        white,
        black
    }

    public enum Levels
    {
        Level_0 = 0
    }


    public class GameControllerScript : MonoBehaviour
    {
        


        public static void StartGame()
        {
            CameraController.Available = true;
            PlayerControllerScript.Available = true;
        }
    }
}
