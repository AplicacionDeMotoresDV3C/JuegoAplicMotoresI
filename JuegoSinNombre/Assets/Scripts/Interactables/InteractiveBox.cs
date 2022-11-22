using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour, IInteractable
{
    Rigidbody2D myRB;
    bool canMoveBox = true;


    private void Start()
    {
        myRB = gameObject.GetComponent<Rigidbody2D>();
        myRB.bodyType = RigidbodyType2D.Static;
    }

    public void Activate()
    {
        canMoveBox = true;
        myRB.bodyType = RigidbodyType2D.Dynamic;
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Desactivate()
    {
        canMoveBox = false;
        myRB.bodyType = RigidbodyType2D.Static;
    }
}
