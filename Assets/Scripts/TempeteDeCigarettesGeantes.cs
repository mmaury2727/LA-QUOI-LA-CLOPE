using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempeteDeCigarettesGeantes : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Clope")
                {
                    print("touché");
                    hit.rigidbody.gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Lose")
        {
            print("t'as perdu CHEHH");
        }
    }
}
