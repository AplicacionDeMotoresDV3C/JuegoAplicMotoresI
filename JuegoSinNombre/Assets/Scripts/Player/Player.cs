using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] InteractionDetector _interactable;
    [SerializeField] BusyChecker _busy;
    [SerializeField, Range(0, 10)] float _jumpForce;
    [SerializeField] float speedRoll = 0;
    [SerializeField] Collider2D _collider;
    bool deadh = false;
    float _speedMove;

    public GameManager myGameManager;
    public float xInput;

    bool _lookRight;
    Vector2 _movement;
    private void Start()
    {
        Health.OnDeath += Death;
        _speedMove = speed;
    }
    private void Update()
    {
        VoltearPersonaje();
        if (!deadh)
        {
            Inputs();
            Move(_movement);
            Rolling();
        }
    }
    void FixedUpdate()
    {
        float xVelocity = _movement.normalized.x * speed;
        _rb.velocity = new Vector2(xVelocity, _rb.velocity.y);
    }

    protected override void Attack()
    {
        myAnim.AttackAnimation();

    }
    public void HeatBoxAttack()
    {
        _collider.enabled = true;
    }
    public void HeatBoxAttackEnd()
    {
        _collider.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            _collider.enabled = false;
        }
    }

    protected override void Move(Vector2 direction)
    {
        speed = _speedMove;
        _movement = new Vector2(xInput, 0f);
        myAnim.MoveAnimation(xInput);
    }
    void Inputs()
    {
        xInput = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump") && _busy.CanJump())
        {
            myAnim.JumpAnimation();
            Jump();
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
            speed = 0;
            transform.Translate(Vector3.right * speedRoll * Time.deltaTime);
        }
        else
        {
            speed = 0;
            transform.Translate(Vector3.right * -speedRoll * Time.deltaTime);
        } 
    }
    void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _busy.isJumping = true;
    }
    void Death()
    {
        speed = 0;
        deadh = true;

    }
}
