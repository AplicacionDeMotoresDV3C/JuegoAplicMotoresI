using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] Rigidbody2D _rb;
    Vector2 direction;

    [Header("movimiento")]
    float _direction = 0f;
    [SerializeField] float _speedMove;
    [SerializeField] float _swayMove;
    Vector3 _speed = Vector3.zero;
    bool _lookRight;
    Vector3 speedTarget;
    float move;

    [Header("Salto")]
    [SerializeField] float _addForce;
    [SerializeField] LayerMask _floor;
    [SerializeField] Transform _checkFloor;
    [SerializeField] Vector3 dimensionBox;
     bool _jump = false;
     bool _isFloor;

    private void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal") * _speedMove;

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;

        }
    }

    private void FixedUpdate()
    {
        _isFloor = Physics2D.OverlapBox(_checkFloor.position, dimensionBox, 0f, _floor);
        Move(direction, _direction * Time.fixedDeltaTime);
        _jump = false;
    }

    protected override void Attack()
    {

    }

    protected override void Move(Vector2 direction, float move)
    {
        speedTarget = new Vector2(move, _rb.velocity.y);
        _rb.velocity = Vector3.SmoothDamp(_rb.velocity, speedTarget, ref _speed, _swayMove);

        if (move < 0 && !_lookRight)
        {
            girar();
        }
        else if (move > 0 && _lookRight)
        {
            girar();
        }
    }
    void girar()
    {
        _lookRight = !_lookRight;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;

    }

}
