using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] bool isMultiplicator = false;
    [SerializeField] int value = 0;
    private bool hasBeenGiven = false;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

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
