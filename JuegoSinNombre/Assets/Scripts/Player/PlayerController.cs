using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _maxStamina = 10;
    float _stamina = 10;
    float _staminaRecovery;
    [SerializeField, Range(0, 20)] float _jumpForce = 10;
    float _rollCooldown;
    float _rolltimer;

    void Update()
    {
        StaminaRecovery();
    }
    private void StaminaRecovery()
    {
        if (_stamina >= _maxStamina)
        {
            _stamina = _maxStamina;
        }
        else if (_stamina < _maxStamina)
        {
            _staminaRecovery += Time.deltaTime;
            _stamina += _staminaRecovery;
        }
    }

}
