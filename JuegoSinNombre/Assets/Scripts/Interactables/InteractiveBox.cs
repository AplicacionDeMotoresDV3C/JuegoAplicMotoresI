using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gabriele Peruilh, Guido
public class InteractiveBox : MonoBehaviour, IInteractable
{
    Rigidbody2D myRB;


    private void Start()
    {
        myRB = gameObject.GetComponent<Rigidbody2D>();
        myRB.bodyType = RigidbodyType2D.Static;
    }

    public void Activate()
    {
        myRB.bodyType = RigidbodyType2D.Dynamic;
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Desactivate()
    {
        myRB.bodyType = RigidbodyType2D.Static;
    }
}
