using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyChecker : MonoBehaviour
{
    bool _isGrounded;
    [SerializeField] float _coyoteTime;
    [SerializeField] float _maxCoyoteTime = 0.1f;
    bool coyoteCheck = false;
    public bool isJumping = false;
    bool _isRolling = false;
  
    public bool isAttacking = false;
    [SerializeField] bool _isFloor;
    [SerializeField] Transform _floorCheck;
    [SerializeField] LayerMask _floorLayer;
    [SerializeField] float _coolDownRollMax;
    [SerializeField, Range(0, 10)] float _floorCheckRadius;
    const float _rollingTime = 1.01f;
    float _time;
    bool _coolDownFinish = true;

    public bool IsRolling => _isRolling;
    private void Update()
    {

        checkFloor();
        if (_time < _coolDownRollMax + _rollingTime)
        {
            _time += 1 * Time.deltaTime;
            if (_time > _rollingTime) _isRolling = false;
        }
        else _coolDownFinish = true;
    }
    public bool CanJump()
    {
        if (_isFloor)
        {
            return true;
        }
        return false;

    }
    public bool CanRoll()
    {

        if (_isFloor && !_isRolling && _coolDownFinish)
        {
            return true;
        }

        return false;
    }
    public void Roll()
    {
        _coolDownFinish = false;
        _isRolling = true;
        _time = 0;
    }

    public bool CanAttacking()
    {
        if (!_isRolling)
        {
            return true;
        }
        return false;
    }

    void checkFloor()
    {
        _isFloor = Physics2D.OverlapCircle(_floorCheck.position, _floorCheckRadius, _floorLayer);
        if (_isFloor)
        {
            coyoteCheck = true;
            _coyoteTime = 0;
        }
    }
}
