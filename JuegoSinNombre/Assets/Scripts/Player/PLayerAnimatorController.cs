using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAnimatorController : MonoBehaviour
{
    [SerializeField] Animator _ani;
    [SerializeField] Player _playerController;


    public void Walk()
    {
        _ani.SetFloat("Horizontal", Mathf.Abs(_playerController.xInput));
    }
    public void Jump()
    {
        _ani.SetBool("Jump", true);
    }
    public void Roll()
    {
        _ani.SetBool("Roll", true);
    }
    public void rollEnd()
    {
        _ani.SetBool("Roll", false);
    }
}
