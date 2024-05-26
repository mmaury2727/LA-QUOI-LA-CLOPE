using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Manager manager;
    private Rigidbody playerRb;
    private float speed = 10.0f;
    private float jumpForce = 6f;
    private float xBound = 3.6f;
    private bool isOnGround = true;
    private Animator animator;

    private float touchPosX;
    public float throwForce = 4f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        if (manager.lost){
                // playerRb.constraints = RigidbodyConstraints.None;
                animator.SetTrigger("Catched");
        }
    }

    float GetTouchXPosition()
    {
        float touchPosX = Input.GetTouch(0).position.x;
        Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(new Vector3(touchPosX, Mathf.Abs(transform.position.y - Camera.main.transform.position.y), Mathf.Abs(transform.position.z - Camera.main.transform.position.z)));
        return touchPosWorld.x;
    }

    void MovePlayer()
    {
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        } 
        else if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        } 
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    transform.position = new Vector3(GetTouchXPosition(), transform.position.y, transform.position.z);
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    transform.position = new Vector3(GetTouchXPosition(), transform.position.y, transform.position.z);
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