using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyChecker : MonoBehaviour
{
    bool _isGrounded;
    float _coyoteTime;
    float _maxCoyoteTime;
    public bool _isJumping = false;
    public bool _isRolling = false;
    public bool _isAttacking = false;
    bool _isFloor;
    [SerializeField] Transform _floorCheck;
    [SerializeField] LayerMask _floorLayer;
    [SerializeField, Range(0, 10)] float _floorCheckRadius;
    private void Update()
    {
        _isFloor = Physics2D.OverlapCircle(_floorCheck.position, _floorCheckRadius, _floorLayer);
    }

    public bool CanJump()
    {
        if (!_isAttacking && !_isRolling && _isFloor)
        {
            _isJumping = true;
            return true;
        }
        return false;
    }
    public void CanRoll()
    {

    }
}
