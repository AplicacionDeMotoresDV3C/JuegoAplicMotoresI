using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] InteractionDetector _interactable;
    [SerializeField] BusyChecker _busy; 
    [SerializeField, Range(0, 10)] float _jumpForce;
    [SerializeField] float speedRoll;

    public GameManager myGameManager;
    public float xInput;

    bool _lookRight;
    Vector2 _movement;
    private void Start()
    {
        Health.OnDeath += Death;
    }
    private void Update()
    {
        Move(_movement);
        VoltearPersonaje();
        Inputs();
        Rolling();

    }
    void FixedUpdate()
    {
        float xVelocity = _movement.normalized.x * speed;
        _rb.velocity = new Vector2(xVelocity, _rb.velocity.y);
    }

    protected override void Attack()
    {
        Move(Vector2.zero);
        myAnim.AttackAnimation();
    }

    protected override void Move(Vector2 direction)
    {
        _movement = new Vector2(xInput, 0f);
        myAnim.MoveAnimationPlayer(xInput);
    }
    void Inputs()
    {
        xInput = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump") && _busy.CanJump())
        {
            myAnim.JumpAnimation();
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.E) && _interactable._interatablesInRange.Count > 0)
        {
            _interactable.Interatable();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            myGameManager.LoadPosition();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && _busy.CanRoll())
        {
            _busy.Roll();
            myAnim.RollAnimation();
        }
    }
    void VoltearPersonaje()
    {
        if (xInput < 0)
        {
            _lookRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (xInput > 0)
        {
            _lookRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    void Rolling()
    {
        if (!_busy.IsRolling) return;
        if (_lookRight)
        {
            transform.Translate(Vector3.right * speedRoll * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * -speedRoll * Time.deltaTime);
        }
    }
    void Death()
    {
        Destroy(this, 1.02f);
    }
}
