using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static PlayerCollision pc;
    [SerializeField] private Animator anim;

    private bool isHit = false;
    private float delayBeforeFall = 0.0001f; 

    private void Awake()
    {
        pc = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clope" && !isHit)
        {
            isHit = true;
            StartCoroutine(TriggerFallAnimation());
        }
    }

    IEnumerator TriggerFallAnimation()
    {
        yield return new WaitForSeconds(delayBeforeFall);
        anim.SetBool("IsDown", true);
    }

    public bool GetIsHit()
    {
        return isHit;
    }
}
