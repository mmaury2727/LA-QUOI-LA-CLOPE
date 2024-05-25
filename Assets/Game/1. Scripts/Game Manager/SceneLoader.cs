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
    private AsyncOperation loading;

    private IEnumerator LoadNextGame(string gameName)
    {
        loading = SceneManager.LoadSceneAsync(gameName, LoadSceneMode.Additive);
        loading.allowSceneActivation = false;
        gameLoaded = gameName;

        yield return true;
    }
    private IEnumerator UnloadCurrentGame()
    {

        SceneManager.UnloadSceneAsync(gameLoaded);

        yield return true;
    }

    public IEnumerator ChangeMiniGame(string gameName)
    {
        if (gameLoaded != "")
        {
            StartCoroutine(UnloadCurrentGame());
            yield return false;
        }

        StartCoroutine(LoadNextGame(gameName));
        yield return true;

        gameLoaded = gameName;
    }

    public IEnumerator ActivateMiniGame()
    {
        loading.allowSceneActivation = true;
        yield return true;
    }
}
