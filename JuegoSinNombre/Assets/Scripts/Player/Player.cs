using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    Vector3 posPj;
    [SerializeField] InteractionDetector _interactable;
    public GameManager myGameManager;
    Rigidbody2D _rb;
    float _movement;
    float _baseGravity;

    [SerializeField] float _rollTime = 0.2f;
    [SerializeField] float _rollForce = 20f;
    [SerializeField] float _cooldown = 1f;
    bool _isRoll;
    bool _CanRoll;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _baseGravity = _rb.gravityScale;
    }
    private void Update()
    {

    }
    void FixedUpdate()
    {
        Move(posPj);
        InputPlayer();
    }
    protected override void Attack() { }


    protected override void Move(Vector2 direction)
    {
        
        posPj = transform.position;

        posPj += new Vector3(_movement, 0f, 0) * speed * Time.deltaTime;

        transform.position = posPj;
       
        
    }
    void InputPlayer()
    {

        posPj = Vector3.zero;
        _movement = Input.GetAxisRaw("Horizontal");

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
            StartCoroutine(Roll());
        }
    }
    IEnumerator Roll()
    {
        _isRoll = true;
        _CanRoll = false;
        _rb.gravityScale = 0f;
        _rb.velocity = new Vector2(_movement * _rollForce, 0f);
        yield return new WaitForSeconds(_rollTime);
        _isRoll = false;
        _rb.gravityScale = _baseGravity;
        yield return new WaitForSeconds(_cooldown);
        _CanRoll = true;
    }


}
