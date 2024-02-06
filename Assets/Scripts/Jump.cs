using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private CharacterController cc;
    private Vector3 moveDir;

    [SerializeField] private float gravity;
    [SerializeField] float jumpForce;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void LateUpdate()
    {
        moveDir = new Vector3(moveDir.x, moveDir.y, moveDir.z);

#if UNITY_EDITOR || UNITY_STANDALONE // si on est sur PC
        if (Input.GetKeyDown(KeyCode.Mouse0) && cc.isGrounded){
            moveDir.y = jumpForce;
        }
#endif

#if UNITY_ANDROID || UNITY_IPHONE // si on est sur mobile
        if(Input.touches.Length == 1 && cc.isGrounded){
            moveDir.y = jumpForce;
        }
#endif
        moveDir.y -= gravity * Time.deltaTime;
        cc.Move(moveDir * Time.deltaTime);

    }
}
