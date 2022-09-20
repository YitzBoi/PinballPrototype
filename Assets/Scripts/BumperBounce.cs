using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBounce : MonoBehaviour
{
    [SerializeField] private int forceMultiplier = 1;
    [SerializeField] private int scoreAmount = 50;

    private const int MaxVelocity = 30;

    private GameManager gameManager;

    private void Start()
    {
         gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.velocity.x <= MaxVelocity &&
            collision.rigidbody.velocity.y <= MaxVelocity &&
            collision.rigidbody.velocity.z <= MaxVelocity)
        {
            collision.rigidbody.velocity *= forceMultiplier;
            gameManager.AddToScore(scoreAmount);
        }
    }
}
