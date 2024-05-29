using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersManager : MonoBehaviour
{
    [SerializeField] private BlowVictoryManager victoryManager = default;

    private void OnCollisionEnter(Collision collision) {
        victoryManager.Win();
    }

    private void OnTriggerEnter(Collider other)
    {
        victoryManager.Loose();
    }
}
