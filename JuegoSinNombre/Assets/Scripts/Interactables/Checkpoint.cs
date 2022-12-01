using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour, IInteractable
{
    bool canUseCheckpoint = true;
    GameManager myGameManager;

    public void Activate()
    {
        myGameManager = GameManager.Instance;
        canUseCheckpoint = false;
        myGameManager.SavePosition();
    }

    public bool CanInteract()
    {
        return canUseCheckpoint;
    }

    public void Desactivate()
    {

    }
}
