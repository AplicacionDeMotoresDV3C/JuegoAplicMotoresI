using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    public List<IInteractable> _interatablesInRange = new List<IInteractable>();

    public void Interatable()
    {
        var interactable = _interatablesInRange[0];
        interactable.Activate();
        if (!interactable.CanInteract())
        {
            _interatablesInRange.Remove(interactable);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable.CanInteract())
        {
            _interatablesInRange.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponent<IInteractable>();
        if (_interatablesInRange.Contains(interactable))
        {
            interactable.Desactivate();
            _interatablesInRange.Remove(interactable);
        }
    }
}
