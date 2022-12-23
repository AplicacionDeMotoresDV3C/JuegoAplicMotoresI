using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFinal - Gabriele Peruilh, Guido
public class Switch : MonoBehaviour, IInteractable
{
    private bool doorIsOpen = false;
    Color DoorCloseColor = Color.red;
    Color DoorOpenColor = Color.green;
    Renderer myRenderer;
    BoxCollider2D doorCollider;
    public GameObject door;


    private void Start()
    {
        myRenderer = door.GetComponent<Renderer>();
        doorCollider = door.GetComponent<BoxCollider2D>();
        myRenderer.material.color = DoorCloseColor;
    }

    public void Activate()
    {
        doorIsOpen = true;
        myRenderer.material.color = DoorOpenColor;
        doorCollider.enabled = false;
    }

    public bool CanInteract()
    {
        return !doorIsOpen;
    }

    public void Desactivate() { }

}
