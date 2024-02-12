using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static PlayerCollision pc;

    private bool isHit = false;

    private void Awake()
    {
        pc = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Clope")
        {
            isHit = true;

        }
    }

    public bool GetIsHit()
    {
        return isHit;
    }
}