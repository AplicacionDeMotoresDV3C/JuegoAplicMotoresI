using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, IInteractable
{
    bool canUseCheckpoint;
    GameManager myGameManager;

    private void Start()
    {

    }
    public void Activate()
    {
        myGameManager = GameManager.Instance;
        myGameManager.SavePosition();
    }

    public bool CanInteract()
    {
        return !canUseCheckpoint;
    }

    public void Desactivate()
    {

    }
}
