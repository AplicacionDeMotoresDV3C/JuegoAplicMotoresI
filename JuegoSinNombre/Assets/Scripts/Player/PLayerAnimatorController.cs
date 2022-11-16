using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAnimatorController : MonoBehaviour
{
    [SerializeField] Animator _ani;


    public void Walk()
    {
        _ani.SetBool("Movimiento", true);
    }
    public void Jump()
    {
        _ani.SetBool("Jump", true);
    }
}
