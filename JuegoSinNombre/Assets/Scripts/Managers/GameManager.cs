using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerPosition;

    private void Start()
    {
        playerPosition = player.transform.position;
    }

    public void SavePosition()
    {
        playerPosition = player.transform.position;
    }

    public void LoadPosition()
    {
        player.transform.position = playerPosition;
    }

}
