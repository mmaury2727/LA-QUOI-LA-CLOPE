using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryManagerBabyfoot : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator = default;
    [SerializeField] private Animator keeperAnimator = default;
    [SerializeField] private Animator safeAnimator = default;
    [SerializeField] private Rigidbody coinBody = default;

    public void Win()
    {
        //GameStats.Instance.winned = true;
        playerAnimator.SetBool("Win", true);
        keeperAnimator.SetBool("Win", true);
        safeAnimator.SetBool("Win", true);
    }

    public void Lose()
    {
        playerAnimator.SetBool("Lose", true);
        keeperAnimator.SetBool("Lose", true);
        coinBody.drag = 13;
    }
}
