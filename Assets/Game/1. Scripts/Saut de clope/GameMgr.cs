using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr gMgr;

    private bool win = true;
    private bool timerEnded = false;
    private bool canPlayAudioClip = true;
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
        AudioManager.Instance.PlayAudio("Ambiance saut de clope");
        canPlayAudioClip = true;
    }

    private void Update()
    {
        if (timerEnded && !PlayerCollision.pc.GetIsHit())
        {
            print("on gagne");
            if (canPlayAudioClip)
            {
                AudioManager.Instance.PlayAudio("Victoire Saut De Clope");
                canPlayAudioClip = false;
            }
            
            victory.SetActive(true);
            victoryBackground.SetActive(true);
        }else if (timerEnded && PlayerCollision.pc.GetIsHit())
        {
            print("on perd");
            if (canPlayAudioClip)
            {
                AudioManager.Instance.PlayAudio("Defaite saut de clope");
                canPlayAudioClip = false;
            }
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
