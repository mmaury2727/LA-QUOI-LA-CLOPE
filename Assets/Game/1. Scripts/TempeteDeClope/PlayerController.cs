using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Manager manager;
    private Rigidbody playerRb;
    private float speed = 10.0f;
    private float jumpForce = 6f;
    private float xBound = 3.6f;
    private float xMin;
    private float xMax;
    private Rect camsize;
    private bool isOnGround = true;
    private Animator animator;

    private float touchPosX;
    public float throwForce = 4f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        animator = GetComponent<Animator>();
        camsize = GameObject.Find("Main Camera").GetComponent<Camera>().pixelRect;
    }

    void Update()
    {
        MovePlayer();
        if (manager.lost){
                // playerRb.constraints = RigidbodyConstraints.None;
                animator.SetTrigger("Catched");
        }
    }

    float convertPosition(float coordX)
    {
        print(coordX);
        return coordX * 7 / camsize.width; // -3.5 et 3.5 (-xBound, xBound)
    }

    float GetTouchXPosition()
    {
        float touchPosX = Input.GetTouch(0).position.x;
        print("posPoubelleX = " + transform.position.x);
        //Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPosX, Mathf.Abs(transform.position.y - Camera.main.transform.position.y), Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
        return touchPosX;
    }

    void MovePlayer()
    {
        //if (transform.position.x < -xBound)
        //{
        //    transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        //} 
        //else if (transform.position.x > xBound)
        //{
        //    transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        //} 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float pourcent = ((touch.position.x/camsize.width) * 100);

              
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    transform.position = new Vector3(convertPosition(GetTouchXPosition()) - 2.5f, transform.position.y, transform.position.z);
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    transform.position = new Vector3(convertPosition(GetTouchXPosition()) - 2.5f, transform.position.y, transform.position.z);
                    break;
                case TouchPhase.Ended:
                    playerRb.velocity = Vector2.zero;
                    break;
            }
        }
    }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
        }

    void Throw() {
            // playerRb.AddForce((transform.right * 100) * throwForce, ForceMode.Impulse);
            // float angle = Mathf.Atan2(playerRb.velocity.y, playerRb.velocity.x) * 120;
            // playerRb.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Clope"))
        {
            Destroy(other.gameObject);
            manager.UpdateScore(1);
            if (manager.score >= manager.scoreToWin){
                // playerRb.constraints = RigidbodyConstraints.None;
                animator.SetTrigger("Catched");
            }
        }
    }
}