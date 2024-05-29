using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyClopeVictoryManager : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator = default;
    [SerializeField] private Animator keeperAnimator = default;
    [SerializeField] private Animator safeAnimator = default;
    [SerializeField] private Animator bgAnimator = default;
    [SerializeField] private Animator pointsAnimator = default;
    [SerializeField] private Rigidbody coinBody = default;

    public void Win()
    {
        AudioManager.Instance.PlayAudio("But Baby");
        GameStats.Instance.winned = true;
        playerAnimator.SetBool("Win", true);
        keeperAnimator.SetBool("Win", true);
        safeAnimator.SetBool("Win", true);
        bgAnimator.SetBool("Win", true );
        pointsAnimator.SetBool("Win", true);
    }

    public void Lose()
    {
        playerAnimator.SetBool("Lose", true);
        keeperAnimator.SetBool("Lose", true);
        bgAnimator.SetBool("Lose", true);
        coinBody.drag = 13;
    }
}
