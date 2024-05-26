using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField] private int gameDifficulty = 1;
    [SerializeField] private float miniGamesTimer = 1f;
    [SerializeField] private int playerLifes = 4;
    [SerializeField] private int gameScore = 0;
    [SerializeField] private bool isMiniGameWinned = false;

    [SerializeField] private List<MiniGame> miniGamesList;

    [System.Serializable]
    public struct MiniGame
    {
        public string name;
        public string message;
        public Interaction interaction;
    }

    public enum Interaction
    {
        Tap,
        MultiTap,
        Drag,
        Rug
    }

    public static GameStats Instance { private set; get; }

    public int difficulty
    {
        get { return gameDifficulty; }
        set { gameDifficulty = value; }
    }
    public float timer
    {
        get { return miniGamesTimer; }
        set { miniGamesTimer = value; }
    }
    public bool winned
    {
        get { return isMiniGameWinned; }
        set { isMiniGameWinned = value; }
    }
    public int lifes
    {
        get { return playerLifes; }
        set { playerLifes = value; }
    }
    public int score
    {
        get { return gameScore; }
        set { gameScore = value; }
    }
    public List<MiniGame> miniGames
    {
        get { return miniGamesList; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
    }
}
