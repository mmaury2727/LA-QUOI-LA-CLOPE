using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    public float yDestroy = -2.0f;
    private Manager manager;

    public void TurnOff()
    {
        this.enabled = false;
    }

    void Update()
    {

        if (transform.position.y < yDestroy)
        {
            // Destroy(gameObject);
            Debug.Log("trigger lose");
            GameObject background = GameObject.FindGameObjectWithTag("Background");
            manager = GameObject.Find("Manager").GetComponent<Manager>();

            if (background != null)
            {
                Animator animator = background.GetComponent<Animator>();
                if (animator != null && !manager.lost)
                {
                    animator.SetBool("OnLose", true);
                    manager.LoseGame();
                    TurnOff();
                }
            }
        }
    }
}
