using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClopeCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lose")
        {
            print("t'as perdu CHEHH");
        }
    }
}
