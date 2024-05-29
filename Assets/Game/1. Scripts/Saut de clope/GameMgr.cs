using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr gMgr;

    private bool win = true;
    private bool timerEnded = false; 
    private PlayerCollision pc;

    [SerializeField] GameObject victory;

    [SerializeField] GameObject lost;
    [SerializeField] GameObject gameOverBackground;

    [SerializeField] GameObject victoryBackground;


    private void Awake()
    {
        gMgr = this;
    }
    void Start()
    {
        StartCoroutine("WinOrLose");
    }

    private void Update()
    {
        if (timerEnded && !PlayerCollision.pc.GetIsHit())
        {
            print("on gagne");
            victory.SetActive(true);
            victoryBackground.SetActive(true);
        }else if (timerEnded && PlayerCollision.pc.GetIsHit())
        {
            print("on perd");
            lost.SetActive(true);
            gameOverBackground.SetActive(true);
        }
    }

    IEnumerator WinOrLose() 
    {
        yield return new WaitForSeconds(7f);
        timerEnded = true;
    }

}
