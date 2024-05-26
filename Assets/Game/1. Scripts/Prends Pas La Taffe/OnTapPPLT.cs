using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTapPPLT : MonoBehaviour
{
    [SerializeField] private Rigidbody rb = default;
    [SerializeField] private int forceStrength = default;

    void LateUpdate()
    {

#if UNITY_ANDROID || UNITY_IPHONE // si on est sur mobile
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began){
            rb.AddForce(Vector3.up * forceStrength);
            Debug.Log("Touched");
        }
#endif
    }
}
