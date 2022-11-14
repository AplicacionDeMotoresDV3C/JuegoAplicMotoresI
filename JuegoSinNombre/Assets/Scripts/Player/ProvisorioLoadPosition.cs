using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvisorioLoadPosition : MonoBehaviour
{
    public GameManager myGameManager;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            myGameManager.LoadPosition();
        }
    }
}
