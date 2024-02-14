using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static PlayerCollision pc;
    [SerializeField] private Animator anim;

    private bool isHit = false;

    private void Awake()
    {
        pc = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clope")
        {
            isHit = true;
            anim.SetBool("IsDown", true);
        }
    }

    public bool GetIsHit()
    {
        return isHit;
    }
}