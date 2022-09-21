using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class demoSpriteBlink : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_mesh;
    [SerializeField] private Sprite[] text_sprite;
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

            sprite_mesh.sprite = text_sprite[bid];

            if (++bid >= max_cycle) bid = 0;
        }
    }
    
    public void OnLostBall()
    {
        Debug.Log("COCK");
        StopAllCoroutines();
        isActive = false;
        sprite_mesh.sprite = text_sprite[0];
    }
}
