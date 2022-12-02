using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyChecker : MonoBehaviour
{
    [SerializeField] float _coyoteTime;
    [SerializeField] float _maxCoyoteTime = 0.1f;
    public bool isJumping = false;
    bool _isRolling = false;
    bool _isBlocking = false;
    private bool isAttacking = false;
    [SerializeField] bool _isFloor;
    [SerializeField] Transform _floorCheck;
    [SerializeField] LayerMask _floorLayer;
    [SerializeField] float _coolDownRollMax;
    [SerializeField, Range(0, 10)] float _floorCheckRadius;
    const float _rollingTime = 1.01f;
    float _time;
    bool _coolDownFinish = true;
    bool _canMove = true;

    public bool IsRolling => _isRolling;

    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public bool IsFloor { get => _isFloor; set => _isFloor = value; }
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public bool IsBlocking { get => _isBlocking; set => _isBlocking = value; }

    private void Update()
    {
        _isFloor = Physics2D.OverlapCircle(_floorCheck.position, _floorCheckRadius, _floorLayer);

        if (isJumping)
        {
            _canMove = true;
        }
        else if (!isJumping && IsAttacking)
        {
            _canMove = false;
        }

        if (!_isFloor)
        {
            _coyoteTime += 1 * Time.deltaTime;
        }
        else _coyoteTime = 0;

        if (_time < _coolDownRollMax + _rollingTime)
        {
            _time += 1 * Time.deltaTime;
            if (_time > _rollingTime) _isRolling = false;
        }
        else _coolDownFinish = true;
    }
    public bool CanJump()
    {
        if ((_isFloor || (!_isFloor && _coyoteTime <= _maxCoyoteTime)) && !_isRolling && !isJumping && !_isBlocking)
        {
            return true;
        }
        return false;

    }
    public bool CanRoll()
    {
        if (_isFloor && !_isRolling && _coolDownFinish && !isAttacking && !_isBlocking)
        {
            return true;
        }
        return false;
    }

    public bool CanShield()
    {
        if (_isFloor && !isAttacking && !_isRolling && !isJumping)
        {
            return true;
        }
        return false;
    }
    public bool CanAttacking()
    {
        if (!_isRolling && !IsAttacking && !_isBlocking)
        {
            return true;
        }
        return false;
    }
    public void Rolling()
    {
        _coolDownFinish = false;
        _isRolling = true;
        _time = 0;
    }
}
