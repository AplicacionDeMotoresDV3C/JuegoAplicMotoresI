using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] GameManager gm;
    [SerializeField] InteractionDetector _interactable;
    [SerializeField] BusyChecker _busy;
    [SerializeField, Range(0, 10)] float _jumpForce;
    [SerializeField] float speedRoll;
    [SerializeField] Collider2D _colliderAttack;
    bool deadh = false;
    float _stamina;
    float _maxStamina = 10f;
    public Action OnStaminaCHange;

    public GameManager myGameManager;
    public float xInput;

    bool _lookRight;
    Vector2 _movement;

    public float Stamina { get { return _stamina; } }
    public float MaxStamina { get { return _maxStamina; } }
    private void Start()
    {
        Health.OnTakeDamage += IsAttacked;
        Health.OnDeath += Death;
        _stamina = _maxStamina;
    }
    private void Update()
    {
        VoltearPersonaje();
        if (!deadh)
        {
            Inputs();
            Move(_movement);
        }
        Rolling();
        StaminaRecovery();
    }
    void FixedUpdate()
    {
        float xVelocity = _movement.normalized.x * speed;
        _rb.velocity = new Vector2(xVelocity, _rb.velocity.y);
    }

    protected override void Attack()
    {
        if (_stamina < 2) return;
        _stamina -= 2;
        OnStaminaCHange?.Invoke();
        myAnim.AttackAnimation();
    }
    public void HeatBoxAttack()
    {
        _colliderAttack.enabled = true;
    }
    public void HeatBoxAttackEnd()
    {
        _colliderAttack.enabled = false;
        _busy.isAttacking = false;
    }
    public void ShieldEvent()
    {
        Health.isInvunerable = true;
    }
    public void ShieldEndEvent()
    {
        Health.isInvunerable = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            _colliderAttack.enabled = false;
        }
    }

    protected override void Move(Vector2 direction)
    {
        _movement = new Vector2(xInput, 0f);
        myAnim.MoveAnimation(Mathf.Abs(xInput));
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
    public void IsAttacked()
    {
        _stamina--;
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
}
