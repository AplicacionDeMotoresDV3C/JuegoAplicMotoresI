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

    [SerializeField, Range(0, 10)] float _jumpForce;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        Move(_movement);
       

        _isFloor = Physics2D.OverlapCircle(_floorCheck.position, _floorCheckRadius, _floorLayer);

     
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
        float xInput = Input.GetAxisRaw("Horizontal");
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
    }
}