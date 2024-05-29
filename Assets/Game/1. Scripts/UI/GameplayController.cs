using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using Interaction = GameStats.Interaction;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private GameObject tap = default;
    [SerializeField] private GameObject spam = default;
    [SerializeField] private GameObject drag = default;
    [SerializeField] private GameObject rug = default;

    public void ActivateAnimation(Interaction gameplay)
    {
        foreach (Transform anim in transform)
        {
            anim.gameObject.SetActive(false);
        }

        switch (gameplay)
        {
            case Interaction.Tap:
                tap.SetActive(true);
                break;
            case Interaction.Drag:
                drag.SetActive(true);
                break;
            case Interaction.Rug:
                rug.SetActive(true);
                break;
            case Interaction.MultiTap:
                spam.SetActive(true);
                break;
        }
    }
}
