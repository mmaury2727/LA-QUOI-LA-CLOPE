using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private bool isNextGameLoaded = false;
    private bool isCurrentGameLoaded = false;
    private bool isGameReady = false;
    private string gameLoaded = "";

    public bool isReady
    {
        get { return isGameReady; }
        set { isGameReady = value; }
    }
    private IEnumerator LoadNextGame(string gameName)
    {
        isNextGameLoaded = false;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        isNextGameLoaded = true;
    }
    private IEnumerator UnloadCurrentGame()
    {
        isCurrentGameLoaded = true;

        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(gameLoaded);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        isCurrentGameLoaded = false;
    }

    public IEnumerator ChangeMiniGame(string gameName)
    {
        isGameReady = false;

        if (gameLoaded != "")
        {
            StartCoroutine(UnloadCurrentGame());
        }

        StartCoroutine(LoadNextGame(gameName));

        while (isCurrentGameLoaded && !isNextGameLoaded)
        {
            yield return null;
        }

        gameLoaded = gameName;
        isGameReady = true;
    }
}
