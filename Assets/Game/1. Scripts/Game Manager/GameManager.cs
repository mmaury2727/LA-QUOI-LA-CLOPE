using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
                currentGame = shuffledMiniGames[index];

                LoadNextGame(currentGame);
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

    private void LoadNextGame(MiniGame game)
    {
        canLoad = false;
        AudioManager.Instance.StopAudio();

        if (game.landscapeMode)
        {
            UIManager.Instance.LandscapeMode();
        }

        if (!stats.winned)
        {
            StartCoroutine(DecrementLife());
        }
        else
        {
            StartCoroutine(IncrementScore());
        }

        if (stats.lifes == 0)
        {
            UIManager.Instance.FailMenu();
        }
        else
        {
            UIManager.Instance.ActivateTransition();
            UIManager.Instance.UpdateGameTransition(game);

            StartCoroutine(loader.ChangeMiniGame(game.name));
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    private IEnumerator DecrementLife()
    {
        StartCoroutine(UIManager.Instance.ChangeLifeBar());
        yield return new WaitForSeconds(0.5f);
        stats.lifes -= 1;
    }

    private IEnumerator IncrementScore()
    {
        yield return new WaitForSeconds(0.3f);
        stats.score += 1;
    }

    private void StartMiniGame()
    {
        StartCoroutine(loader.ActivateMiniGame());
        UIManager.Instance.HideTransition();
        UIManager.Instance.UpdateGameStart(currentGame);
        StartCoroutine(LaunchTimer());
        stats.winned = false;
    }
}
