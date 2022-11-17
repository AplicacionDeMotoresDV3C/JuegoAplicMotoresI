using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyPatrol
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _firePoint;

    [SerializeField] ParticleSystem _bloodEffect;

    void Start()
    {
        Health.OnDeath += DeathBehavior;

        //Efecto de sangre... se puede descartar, estaba jugando no mas
        Health.OnTakeDamage += () => { _bloodEffect.Play(); };
        
        myAnim.SetEvent("Shot", Shot);

        //CAMBIAR caundo este el GameManager
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        _checkDistancePlayer = Vector3.Distance(_player.transform.position, transform.position);

        if ( _checkDistancePlayer < _attackDistance)
            Attack();
        else if (_isWaiting)
            WaitPatrol();
        else
            Patrol();
    }
    protected override void Move(Vector2 direction)
    {
        direction.Normalize();

        direction.x = direction.x * speed;
        direction.y = _rb.velocity.y;

        _rb.velocity = direction;

        if (direction.x < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if(direction.x > 0 && transform.localScale.x < 0)
            transform.localScale = new Vector3(1, 1, 1);

        myAnim.MoveAnimation(direction.x * direction.x);
    }

    protected override void Attack()
    {
        Move(Vector2.zero);
        _isWaiting = true;

        if (_player.transform.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        _cooldownTimer += Time.deltaTime;

        if (_attackCooldown < _cooldownTimer)
        {
            myAnim.AttackAnimation();
            _cooldownTimer = 0;
        }
    }

    protected override void Patrol()
    {
        if (Vector2.Distance(transform.position, _wayPoints[_wayPointID].position) > _wayPointMinDistance)
        {
            if (transform.position.x < _wayPoints[_wayPointID].position.x)
                Move(transform.right);
            else
                Move(transform.right * -1);
        }
        else
            _isWaiting = true;
    }

    protected override void WaitPatrol()
    {
        Move(Vector2.zero);

        _waitTimer += Time.deltaTime;

        if(_waitTimer > _waitTime)
        {
            _isWaiting = false;
            _waitTimer = 0;
            NextWayPoint();
        }
    }

    void Shot()
    {
        var b = Instantiate(_bullet).GetComponent<Bullet>();
        b.transform.position = _firePoint.position;
        b.SetDirection(new Vector3(transform.localScale.x,0,0));
    }

    void DeathBehavior()
    {
        _rb.velocity = Vector2.zero;
        _rb.isKinematic = true;

        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject, 2.5f);

        this.enabled = false;
    }
}
