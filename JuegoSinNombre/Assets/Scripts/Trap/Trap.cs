using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] protected Animator _myAnim;
    protected virtual void Activate()
    {
        _myAnim.SetTrigger("Activate");
    }
}
