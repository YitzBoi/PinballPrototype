using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoTargetBlink : MonoBehaviour
{
    [SerializeField] private MeshFilter target_mesh;
    [SerializeField] private Mesh[] target_mesh_states;
    [SerializeField] private float blinkspeed = 0.5f;
    [SerializeField] private float max_cycle = 4;
    private int bid = 0;
    private bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
        {
            isActive = true;
            StartCoroutine(BlinkTarget());
        }
    }

    IEnumerator BlinkTarget()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(blinkspeed);

            target_mesh.mesh = target_mesh_states[bid];

            if (++bid >= max_cycle) bid = 0;
        }
    }
    
    public void OnLostBall()
    {
        Debug.Log("COCK");
        StopAllCoroutines();
        isActive = false;
        target_mesh.mesh = target_mesh_states[0];
    }
}
