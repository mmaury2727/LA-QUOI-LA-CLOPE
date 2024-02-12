using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneLoader loader = default;
    private GameStats stats;

    private bool isRunning = false;
    private bool activeScene = true;
    void Start()
    {
        stats = GameStats.Instance;
    }
    void Update()
    {
        if (!isRunning)
        {
            if (activeScene)
            {
                StartCoroutine(loader.ChangeMiniGame("Test2"));
                StartCoroutine(LaunchTimer());
                activeScene = false;
            }
            else
            {
                StartCoroutine(loader.ChangeMiniGame("Test1"));
                StartCoroutine(LaunchTimer());
                activeScene = true;
            }
        }
    }

    private IEnumerator LaunchTimer()
    {
        isRunning = true;
        yield return new WaitForSeconds(stats.timer);
        isRunning = false;
    }
}
