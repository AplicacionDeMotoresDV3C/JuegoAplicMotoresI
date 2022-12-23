using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFinal - Gabriele Peruilh, Guido
public class FloorRestart : MonoBehaviour
{

    [SerializeField] GameManager myGameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myGameManager.RestartFromCheckpoint();
        }
    }
}
