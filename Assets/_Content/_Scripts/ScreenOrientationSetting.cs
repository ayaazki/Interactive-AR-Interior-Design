using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenOrientationSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "StartScene")
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else if (sceneName == "InterionAR")
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }

    }

}
