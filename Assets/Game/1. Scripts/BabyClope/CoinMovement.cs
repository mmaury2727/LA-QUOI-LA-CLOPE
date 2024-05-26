using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody coinBody = default;
    [SerializeField] private int coinSpeed = 100;
    
    private bool hasBeenHit = false;
    private bool canPush = false;
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {
        if (!hasBeenHit)
        {
            hasBeenHit = true;
            canPush = true;
        }
    }

    private void FixedUpdate()
    {
        if (canPush)
        {
            coinBody.AddForce(new Vector3(0, 0, 1) * coinSpeed);
            canPush = false;
        }
    }
}
