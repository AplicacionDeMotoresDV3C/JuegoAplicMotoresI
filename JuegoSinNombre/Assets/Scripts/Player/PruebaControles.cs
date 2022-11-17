using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaControles : Entity
{
    public GameManager myGameManager;
    float _maxStamina = 10;
    float _stamina = 10;
    float _staminaRecovery;
    [SerializeField, Range(0, 20)] float _jumpForce = 10;
    float _rollCooldown;
    float _rolltimer;
    Vector3 _direction;

    Vector3 _movementInput = Vector3.zero;
    void Update()
    {
        StaminaRecovery();
        Inputs();
        Move(_movementInput);
    }
    void StaminaRecovery()
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
    void Inputs()
    {
        _movementInput = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            _movementInput.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _movementInput.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            myGameManager.LoadPosition();
        }
    }

    protected override void Attack()
    {

    }

    protected override void Move(Vector2 direction)
    {
        //transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
