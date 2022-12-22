using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gabriele Peruilh, Guido
public class Checkpoint : MonoBehaviour, IInteractable
{
    bool canUseCheckpoint = true;
    GameManager myGameManager;
    [SerializeField] protected Animator _myAnim;

    public void Activate()
    {
        myGameManager = GameManager.Instance;
        canUseCheckpoint = false;
        myGameManager.SavePosition();
        _myAnim.SetTrigger("Activate");
    }

    public bool CanInteract()
    {
        return canUseCheckpoint;
    }

    public void Desactivate()
    {

    }
}
