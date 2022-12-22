using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameManager _gm;
    enum NextScene { NextLevel, Win }
    [SerializeField] NextScene nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            if (nextScene == NextScene.Win)
            {
                _gm.Victory();
            }
            else
            {
                _gm.NextLevel("Level2");
                Debug.Log("Siguiente nivel");
            }
        }
    }
}
