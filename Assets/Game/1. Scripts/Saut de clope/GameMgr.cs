using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr gMgr;

    private bool timerEnded = false;
    private PlayerCollision pc;

    [SerializeField] GameObject victory;
    //serializeField permet de rajouter des game object dans unity 

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
            victory.SetActive(true);
            victoryBackground.SetActive(true);
        }else if (timerEnded && PlayerCollision.pc.GetIsHit())
        {
            lost.SetActive(true);
            gameOverBackground.SetActive(true);
        }
    }

    IEnumerator WinOrLose() 
    {
        yield return new WaitForSeconds(3f);
        timerEnded = true;
    }

}
