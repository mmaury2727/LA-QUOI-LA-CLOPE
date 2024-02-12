using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneLoader loader = default;
    private GameStats stats;
    private List<string> shuffledMiniGames = new List<string>();

    private bool isRunning = false;

    void Start()
    {
        stats = GameStats.Instance;
    }
    void Update()
    {
        if (shuffledMiniGames.Count <= 0)
        {
            Debug.Log("hey");
            shuffledMiniGames = ShuffleMiniGames();
        }

        if (!isRunning)
        {
            Debug.Log(shuffledMiniGames.Count);
            int index = UnityEngine.Random.Range(0, shuffledMiniGames.Count - 1);
            LaunchMiniGame(shuffledMiniGames[index]);
            shuffledMiniGames.RemoveAt(index);
            Debug.Log(shuffledMiniGames.Count);
        }
    }

    private List<string> ShuffleMiniGames()
    {
        List<string> list = stats.miniGames;

        int i = 0;
        int max = list.Count;

        while (i < max / 2)
        {
            string value1 = list[i];
            int randInt = UnityEngine.Random.Range(0, max - 1);

            list[i] = list[randInt];
            list[randInt] = value1;

            i++;
        }

        return list;
    }

    private IEnumerator LaunchTimer()
    {
        isRunning = true;
        yield return new WaitForSeconds(stats.timer);
        isRunning = false;
    }

    private void LaunchMiniGame(string gameName)
    {
        StartCoroutine(loader.ChangeMiniGame(gameName));
        StartCoroutine(LaunchTimer());
        isRunning = true;
    }
}
