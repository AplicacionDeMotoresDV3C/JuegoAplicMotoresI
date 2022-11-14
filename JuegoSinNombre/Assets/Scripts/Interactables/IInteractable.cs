using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Activate();
    public bool CanInteract();

    public void Desactivate();
}
