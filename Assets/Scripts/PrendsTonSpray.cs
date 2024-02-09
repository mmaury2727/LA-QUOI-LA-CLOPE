using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrendsTonSpray : MonoBehaviour
{
    [SerializeField] Image[] Jauge = new Image[10];

    int counter = 0;

    bool hasSpray = false;

    
    void Start()
    {
        StartCoroutine("IncreaseJauge");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spray()
    {
        if (!hasSpray)
        {
            if (counter == 6)
            {
                print("t'as gagné");

            }
            else
            {
                print("t'as perdu");
            }
        }
        hasSpray = true;
    }

    IEnumerator IncreaseJauge()
    {
        while(counter < 9)
        {
            yield return new WaitForSeconds(0.7f);
            Jauge[counter].gameObject.SetActive(false);
            Jauge[counter + 1].gameObject.SetActive(true);
            print(counter);
            counter++;
        }
        Jauge[counter].gameObject.SetActive(false);
    }
}
