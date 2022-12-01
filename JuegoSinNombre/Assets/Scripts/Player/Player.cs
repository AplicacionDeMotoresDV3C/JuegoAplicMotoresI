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
    [SerializeField] Collider2D _colliderAttack;
    bool deadh = false;
    float _stamina;
    float _maxStamina = 10f;
    public Action OnStaminaCHange;
    float _speedSave;
    public GameManager myGameManager;
    public float xInput;

    bool _lookRight;
    Vector2 _movement;
    bool _canMove = true;

    public float Stamina { get { return _stamina; } }
    public float MaxStamina { get { return _maxStamina; } }
    private void Start()
    {
        _speedSave = speed;
        // Health.OnTakeDamage += IsAttacked;
        Health.OnDeath += Death;
        _stamina = _maxStamina;
        myAnim.SetEvent("InvulnerableEvent", InvulnerableEvent);
        myAnim.SetEvent("InvulnerableEventEnd", InvulnerableEventEnd);
        myAnim.SetEvent("HeatBoxAttack", HeatBoxAttack);
        myAnim.SetEvent("HeatBoxAttackEnd", HeatBoxAttackEnd);
        myAnim.SetEvent("IsJumping", IsJumping);
    }
    private void Update()
    {
        VoltearPersonaje();
        if (!deadh)
        {
            Inputs();
            Move(new Vector2(xInput, 0f));
        }
        Rolling();
        StaminaRecovery();
        if (!_canMove)
        {
            speed = 0;
        }
        else speed = _speedSave;
        if (_busy.isJumping)
        {
            _canMove = true;
        }
        else if (!_busy.isJumping && _busy.IsAttacking)
        {
            _canMove = false;
        }
    }
    void FixedUpdate()
    {
        float xVelocity = _movement.normalized.x * speed;
        _rb.velocity = new Vector2(xVelocity, _rb.velocity.y);
    }

    protected override void Attack()
    {
        if (_stamina < 2) return;
        //_canMove = false;
        _busy.IsAttacking = true;
        _stamina -= 2;
        OnStaminaCHange?.Invoke();
        myAnim.AttackAnimation();
    }

    protected override void Move(Vector2 direction)
    {
        if (_canMove)
        {
            _movement = direction;
            myAnim.MoveAnimation(Mathf.Abs(_movement.x));
        }
    }
    void Inputs()
    {

        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && _busy.CanJump())
        {
            Jump();
            myAnim.JumpAnimation();
        }
        if (Input.GetKey(KeyCode.E) && _interactable._interatablesInRange.Count > 0)
        {
            _interactable.Interatable();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            myGameManager.LoadPosition();
        }
        if (Input.GetKeyDown(KeyCode.K) && _busy.CanAttacking())
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && _busy.CanRoll())
        {
            if (_stamina >= 2)
            {
                _stamina -= 2;
                OnStaminaCHange?.Invoke();
                _busy.Roll();
                myAnim.RollAnimation();
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            myAnim.ShieldAnimation();
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
    void Jump()
    {
        if (_stamina >= 1)
        {
            _busy.isJumping = true;
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _stamina--;
            OnStaminaCHange?.Invoke();

        }
    }
    public void StaminaRecovery()
    {
        if (_stamina < _maxStamina)
        {
            _stamina += 1 * Time.deltaTime;
            OnStaminaCHange?.Invoke();
        }
        else
        {
            _stamina = _maxStamina;
            OnStaminaCHange?.Invoke();

        }
    }
    void Death()
    {
        deadh = true;
        Destroy(gameObject, 2f);
    }
    public void HeatBoxAttack()
    {
        _colliderAttack.enabled = true;
    }
    public void HeatBoxAttackEnd()
    {
        _colliderAttack.enabled = false;
        _busy.IsAttacking = false;
        _canMove = true;
    }
    public void InvulnerableEvent()
    {
        Health.isInvunerable = true;
        _canMove = false;
    }
    public void InvulnerableEventEnd()
    {
        Health.isInvunerable = false;
        _canMove = true;
    }
    public void IsJumping()
    {
        if (_busy.IsFloor)
        {
            _busy.isJumping = false;
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            _colliderAttack.enabled = false;
        }
    }
}
