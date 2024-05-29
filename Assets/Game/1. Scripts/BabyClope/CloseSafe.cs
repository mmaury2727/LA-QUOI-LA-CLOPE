using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSafe : MonoBehaviour
{
    [SerializeField] BabyClopeVictoryManager manager = default;

    private void OnTriggerEnter(Collider other)
    {
        manager.Win();
    }
}
