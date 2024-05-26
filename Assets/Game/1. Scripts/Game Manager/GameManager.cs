using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using MiniGame = GameStats.MiniGame;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneLoader loader = default;
    [SerializeField] private Animator animator = default;

    private GameStats stats;
    private List<MiniGame> shuffledMiniGames = new List<MiniGame>();
    private MiniGame currentGame;

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

                LoadNextGame(shuffledMiniGames[index].name);

                shuffledMiniGames.RemoveAt(index);
            }

            if (!animator.GetBool("IsSwitching"))
            {
                StartMiniGame();
            }
        }
    }

    private List<MiniGame> ShuffleMiniGames()
    {
        List<MiniGame> list = new List<MiniGame>();

        foreach (MiniGame game in stats.miniGames) 
        { 
            list.Add(game);
        }

        int i = 0;
        int max = list.Count;

        while (i < max / 2)
        {
            MiniGame value1 = list[i];
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
