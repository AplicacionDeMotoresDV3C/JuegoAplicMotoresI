using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    Rigidbody2D _rb;
    Vector2 _movement;
    [SerializeField] Transform _floorCheck;
    [SerializeField] LayerMask _floorLayer;
    [SerializeField, Range(0, 10)] float _floorCheckRadius;
    bool _isFloor;
    [SerializeField] InteractionDetector _interactable;
    public GameManager myGameManager;
    [SerializeField] PLayerAnimatorController _aniPlayer;
    [SerializeField, Range(0, 10)] float _jumpForce;
    float move;

    [Header("Roll")]
    float _gravity;
    public bool dash;
    [SerializeField] float dashTime;
    [SerializeField] float speedDash;
    [SerializeField] Collider2D _colission;
    bool _lookRight;


    bool _canJump;
    public float xInput;
    [SerializeField] Animator _ani;

    private void Awake()
    {

        _rb = GetComponent<Rigidbody2D>();
        _gravity = _rb.gravityScale;

    }
    private void Update()
    {
        Move(_movement, move);
        VoltearPersonaje();


        _isFloor = Physics2D.OverlapCircle(_floorCheck.position, _floorCheckRadius, _floorLayer);
        _aniPlayer.Walk();


    }
    void FixedUpdate()
    {
        float xVelocity = _movement.normalized.x * speed;
        _rb.velocity = new Vector2(xVelocity, _rb.velocity.y);
    }

    protected override void Attack()
    {

    }

    protected override void Move(Vector2 direction, float move)
    {
        xInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(xInput, 0f);

        if (Input.GetButtonDown("Jump") && _isFloor)
        {
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            xInput = 0f;
            dashTime += 1 * Time.deltaTime;
            if (dashTime < 0.35f)
            {
                dash = true;
                _aniPlayer.Roll();
                if (_lookRight == true)
                {
                    transform.Translate(Vector3.right * -speedDash * Time.fixedDeltaTime);
                }
                else if (_lookRight == false)
                {
                    transform.Translate(Vector3.right * speedDash * Time.fixedDeltaTime);
                }
            }
            else
            {
                dash = false;
                _aniPlayer.rollEnd();
            }
        }
        else
        {
            dash = false;
            _aniPlayer.rollEnd();
            dashTime = 0f;
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
