using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBall : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            StartCoroutine("Respawn");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            StopCoroutine("Respawn");
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2);
        gameManager.LoseBall();
        if(gameManager.AnyBallsLeft())
            transform.position = new Vector3(-5, 0.55f, 13);
        else
            gameObject.SetActive(false);
        StopCoroutine("Respawn");
    }
}
