using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyPatrol : Enemy
{
    [SerializeField] protected Transform[] _wayPoints;
    [SerializeField] protected float _waitTime;
    protected float _waitTimer;
    [SerializeField] protected float _wayPointMinDistance;
    protected int _wayPointID = 0;
    protected bool _isWaiting;

    protected void Patrol()
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
    protected void WaitPatrol()
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

    protected void NextWayPoint()
    {
        _wayPointID++;

        if (_wayPointID == _wayPoints.Length)
            _wayPointID = 0;
    }
}
