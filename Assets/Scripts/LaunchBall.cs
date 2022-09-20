using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    private bool holdLaunch = false;
    private float holdLaunchTimer = 0f;
    private Rigidbody ballRigidBody;

    private const int MaxLaunchTimer = 2;
    private const int LauncherMultiplier = 80;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleHoldLaunch();
        HandleLaunchTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ballRigidBody = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ballRigidBody = null;
        }
    }
    
    private Vector3 CreateNewForce(Vector3 otherObjectPosition, float intensity)
    {
        return new Vector3(otherObjectPosition.x - transform.position.x,
            otherObjectPosition.y - transform.position.y,
            otherObjectPosition.z - transform.position.z).normalized * intensity;
    }
    
    private void HandleLaunchTimer()
    {
        if (holdLaunch)
        {
            holdLaunchTimer += Time.deltaTime;
        }
    }

    private void HandleHoldLaunch()
    {
        if (Input.GetButtonDown("Jump"))
        {
            holdLaunch = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            holdLaunch = false;
            HandleLaunchForce();
        }
    }

    private void HandleLaunchForce()
    {
        holdLaunchTimer = Math.Min(holdLaunchTimer, MaxLaunchTimer);

        if (ballRigidBody)
        {
            ballRigidBody.velocity = new Vector3(LauncherMultiplier * holdLaunchTimer, 0, 0);
            holdLaunchTimer = 0;
        }
    }
}
