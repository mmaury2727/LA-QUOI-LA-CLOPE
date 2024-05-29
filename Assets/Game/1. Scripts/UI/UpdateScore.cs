using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    void Update()
    {
        GetComponent<TMP_Text>().text = GameStats.Instance.score.ToString();
    }
}
