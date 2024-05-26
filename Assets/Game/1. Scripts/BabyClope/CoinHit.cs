using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHit : MonoBehaviour
{
    [SerializeField] private Animator animator = default;

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE // si on est sur PC
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("Hit", true);
        }
#endif

#if UNITY_ANDROID || UNITY_IPHONE // si on est sur mobile
        if(Input.touches.Length >= 1 && cc.isGrounded){
            animator.SetBool("Hit", true);
        }
#endif
    }
}
