using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersManager : MonoBehaviour
{
    [SerializeField] private BlowVictoryManager victoryManager = default;

    private void OnCollisionEnter(Collision collision)
    {
        print("win");
        AudioManager.Instance.PlayAudio("Victoire Taffe");
        victoryManager.Win();
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.PlayAudio("Defaite Taffe");
        victoryManager.Loose();
    }
}
