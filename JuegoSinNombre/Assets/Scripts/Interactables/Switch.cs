using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    [SerializeField] float timer;
    [SerializeField] float timeLimit;
    [SerializeField] float timeToLimit;
    private bool doorIsOpen = false;
    public GameObject door = null;

    private void Update()
    {
        Activate();
        Debug.Log(doorIsOpen);
    }

    public void Activate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Apreto E");
            if (!doorIsOpen)
            {
                doorIsOpen = true;
                door.SetActive(false);
                Debug.Log("Abro");
            }
            else
            {
                doorIsOpen = false;
                door.SetActive(true);
                Debug.Log("cierro");
            }
        }
    }

    public void CanInteract()
    {

    }

}
