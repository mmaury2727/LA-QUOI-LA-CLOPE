using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowVictoryManager : MonoBehaviour
{
    [SerializeField] private Animator brainAnim = default;
    [SerializeField] private Animator lungsAnim = default;
    [SerializeField] private Animator heartAnim = default;
    [SerializeField] private Animator stomachAnim = default;
    [SerializeField] private Animator liverAnim = default;
    [SerializeField] private Animator DealerAnim = default;
    [SerializeField] private Animator camAnim = default;
    [SerializeField] private Rigidbody handRb = default;

    public void Win()
    {
        GameStats.Instance.winned = true;
        brainAnim.SetBool("IsWinned", true);
        lungsAnim.SetBool("IsWinned", true);
        heartAnim.SetBool("IsWinned", true);
        stomachAnim.SetBool("IsWinned", true);
        liverAnim.SetBool("IsWinned", true);
        camAnim.SetBool("IsWinned", true);
        DealerAnim.enabled = false;
        handRb.useGravity = false;
        handRb.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Loose()
    {
        brainAnim.SetBool("IsLost", true);
        lungsAnim.SetBool("IsLost", true);
        heartAnim.SetBool("IsLost", true);
        stomachAnim.SetBool("IsLost", true);
        liverAnim.SetBool("IsLost", true);
        handRb.useGravity = false;
        handRb.constraints = RigidbodyConstraints.FreezePositionY;
    }
}
