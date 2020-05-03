using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    #region Data
    public string sceneName;

    private AsyncOperation async;

    private bool waitForLoad;
    private float timer;
    private float timerWait;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        waitForLoad = false;
        timer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void GoToNextScene()
    {
        waitForLoad = true;
        async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        StartCoroutine(LoadNextScene());
    }

   IEnumerator LoadNextScene()
    {
        while (true)
        {
            if (waitForLoad)
            {
                timer += Time.deltaTime;
                if (timer >= timerWait /* async.progress >= 0.9f */)
                {
                    waitForLoad = false;
                    async.allowSceneActivation = true;
                }
            }
            yield return null;
        }
  
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(sceneName);
    }
}
