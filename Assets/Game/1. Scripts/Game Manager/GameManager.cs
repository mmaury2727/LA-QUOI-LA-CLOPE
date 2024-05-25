using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneLoader loader = default;
    [SerializeField] private Animator animator = default;

    private GameStats stats;
    private List<string> shuffledMiniGames = new List<string>();

    private bool isRunning = false;
    private bool canLoad = true;

    void Start()
    {
        stats = GameStats.Instance;
    }
    void Update()
    {
        if (shuffledMiniGames.Count <= 0)
        {
            shuffledMiniGames = ShuffleMiniGames();
        }

        if (!isRunning)
        {

            if (canLoad)
            {
                int index = UnityEngine.Random.Range(0, shuffledMiniGames.Count - 1);

                LoadNextGame(shuffledMiniGames[index]);

                shuffledMiniGames.RemoveAt(index);
            }

            if (!animator.GetBool("IsSwitching"))
            {
                StartMiniGame();
            }
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
        yield return new WaitForSeconds(stats.timer);
        isRunning = false;
        canLoad = true;

        if (stats.winned) animator.SetBool("IsWinned", true);
        else animator.SetBool("IsLost", true);
    }

    private void LoadNextGame(string gameName)
    {
        canLoad = false;
        StartCoroutine(loader.ChangeMiniGame(gameName));
    }

    private void StartMiniGame()
    {
        StartCoroutine(loader.ActivateMiniGame());
        StartCoroutine(LaunchTimer());
    }
}
