using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrendsTonSpray : MonoBehaviour
{
    [SerializeField] Image[] Jauge = new Image[10];

    int counter = 0;
    bool isReady = true;
    
    void Start()
    {
        GoodTiming();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoodTiming()
    {
        if (isReady)
        {
            isReady = false;
            foreach (Image img in Jauge)
            {
                StartCoroutine("IncreaseJauge");
                img.gameObject.SetActive(false);
                Jauge[counter].gameObject.SetActive(true);
            }
        }

    }

    IEnumerator IncreaseJauge()
    {
        yield return new WaitForSeconds(0.7f);
        isReady = true;
        print(counter);
        counter++;
    }
}
