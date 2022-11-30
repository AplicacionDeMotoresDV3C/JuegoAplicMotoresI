using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] protected Animator _myAnim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Activate();
    }

    protected virtual void Activate()
    {
        _myAnim.SetTrigger("Activate");
    }
}
