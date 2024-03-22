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
            Debug.Log("Shuffle");
            shuffledMiniGames = ShuffleMiniGames();
        }

        if (!isRunning)
        {
            int index = UnityEngine.Random.Range(0, shuffledMiniGames.Count - 1);
            LaunchMiniGame(shuffledMiniGames[index]);
            shuffledMiniGames.RemoveAt(index);
        }
    }

    private List<string> ShuffleMiniGames()
    {
        List<string> list = new List<string>();

        foreach (string gameName in stats.miniGames) 
        { 
            list.Add(gameName);
        }

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
        yield return new WaitForSeconds(stats.timer + 2f);
        isRunning = false;
    }

    private void LaunchMiniGame(string gameName)
    {
        StartCoroutine(loader.ChangeMiniGame(gameName));
        StartCoroutine(LaunchTimer());
        isRunning = true;
        GameStats.Instance.winned = false;
    }
}
