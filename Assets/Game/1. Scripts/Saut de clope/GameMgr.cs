using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr gMgr;

    private bool timerEnded = false;
    private PlayerCollision pc;

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
            print("t'as gagné");
        }else if (timerEnded && PlayerCollision.pc.GetIsHit())
        {
            print("t'as perdu CHEHHHHHHHHHHHHHHHHHHHHHHHHHHH");
        }
    }

    IEnumerator WinOrLose() 
    {
        yield return new WaitForSeconds(8f);
        timerEnded = true;
    }

}
