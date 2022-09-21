using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] bool isMultiplicator = false;
    [SerializeField] int value = 0;
    private bool hasBeenGiven = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isMultiplicator && !hasBeenGiven)
        {
            gameManager.ModifyMultiplier(value);
            hasBeenGiven = true;
        }
        else
        {
            gameManager.AddToScore(value);
        }
    }
}
