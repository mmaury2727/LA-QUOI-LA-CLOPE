using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    private bool timerEnded = false;
    private PlayerCollision pc;

    // Start is called before the first frame update
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

    IEnumerator WinOrLose() // On redonne le droit de tuer des ennemis aprés 0.8sec 
    {
        yield return new WaitForSeconds(8f);
        timerEnded = true;
    }

}
