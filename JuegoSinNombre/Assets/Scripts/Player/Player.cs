using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    Vector2 _movement;
    
    
    
    [SerializeField] InteractionDetector _interactable;
    public GameManager myGameManager;
    [SerializeField, Range(0, 10)] float _jumpForce;
    float move;
    [SerializeField] BusyChecker _busy;

    [Header("Roll")]
    float _gravity;
    public bool roll;
    [SerializeField] float rollTime;
    [SerializeField] float speedRoll;
    //[SerializeField] Collider2D _colission;
    bool _lookRight;
    public float xInput;


    private void Start()
    {
        _gravity = _rb.gravityScale;
    }
    private void Update()
    {
        Move(_movement);
        VoltearPersonaje();
        Inputs();

       
        myAnim.MoveAnimation(xInput);

    }
    void FixedUpdate()
    {
        float xVelocity = _movement.normalized.x * speed;
        _rb.velocity = new Vector2(xVelocity, _rb.velocity.y);
    }

    protected override void Attack()
    {

    }

    protected override void Move(Vector2 direction)
    {
        _movement = new Vector2(xInput, 0f);
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            xInput = 0f;
            rollTime += 1 * Time.deltaTime;
            if (rollTime < 0.35f)
            {
                roll = true;
                // _aniPlayer.Roll();
                if (_lookRight == true)
                {
                    transform.Translate(Vector3.right * speedRoll * Time.fixedDeltaTime);
                }
                else if (_lookRight == false)
                {
                    transform.Translate(Vector3.right * -speedRoll * Time.fixedDeltaTime);
                }
            }
            else
            {
                roll = false;
                //_aniPlayer.rollEnd();
            }
        }
        else
        {
            roll = false;
            //_aniPlayer.rollEnd();
            rollTime = 0f;
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
}
