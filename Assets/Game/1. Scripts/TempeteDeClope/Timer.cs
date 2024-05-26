using UnityEngine;
using System.Collections;


public class Timer : MonoBehaviour
{
    public float timer = 3f;
    public Manager manager;

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (timer > 0)
        {
            Debug.Log(timer + " seconds...");
            yield return new WaitForSeconds(1f);
            timer--;
        }

        Debug.Log("Go");
        manager.StartGame();
        Destroy(gameObject); // Destroy the Timer GameObject
    }
}
