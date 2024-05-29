using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    public void LaunchGame()
    {
        StartCoroutine(LOL());
    }

    private IEnumerator LOL()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Management", LoadSceneMode.Single);
        async.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        yield return new WaitForSeconds(3f);

        async.allowSceneActivation = true;
    }
}
