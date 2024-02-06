using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Clope")
        {
            print(" AHHHHHHH JE SUIS TOUCHE ");
        }
    }
}