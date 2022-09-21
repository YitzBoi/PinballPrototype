using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoLetterCycle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] sprite_mesh;
    [SerializeField] private Sprite[] text_sprite;
    [SerializeField] private Sprite[] text_sprite_highlight;
    [SerializeField] private float blinkspeed = 0.5f;
    private int bid = 0;
    private bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
        {
            isActive = true;
            StartCoroutine(CycleText());
        }
    }

    IEnumerator CycleText()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(blinkspeed);

            for (int i = 0; i < text_sprite.Length; i++)
                sprite_mesh[i].sprite = text_sprite[i];

            sprite_mesh[bid].sprite = text_sprite_highlight[bid];

            if (++bid >= text_sprite.Length) bid = 0;
        }
    }

    public void OnLostBall()
    {
        Debug.Log("COCK");
        StopAllCoroutines();
        isActive = false;
        for (int i = 0; i < text_sprite.Length; i++)
            sprite_mesh[i].sprite = text_sprite[i];
    }
}
