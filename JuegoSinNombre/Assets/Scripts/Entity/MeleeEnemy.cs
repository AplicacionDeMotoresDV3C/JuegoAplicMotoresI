using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class MeleeEnemy : EnemyPatrol
{

    [SerializeField] AnimManager _animManager;

    private void Start()
    {

    }
    private void Update()
    {
        if (_isWaiting)
            WaitPatrol();
        else
            Patrol();
    }
    protected override void Attack()
    {
    
    }

    protected override void Move(Vector2 direction)
    {
        direction.Normalize();

        direction.x = direction.x * speed;
        direction.y = _rb.velocity.y;

        _rb.velocity = direction;

        if (direction.x < 0 && transform.localScale.x > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if (direction.x > 0 && transform.localScale.x < 0)
            transform.localScale = new Vector3(1, 1, 1);

        myAnim.MoveAnimation(direction.x * direction.x);
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

        if (_waitTimer > _waitTime)
        {
            _isWaiting = false;
            _waitTimer = 0;
            NextWayPoint();
        }
    }
}
