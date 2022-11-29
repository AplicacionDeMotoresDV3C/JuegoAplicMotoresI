using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class MeleeEnemy : EnemyPatrol
{

    [SerializeField] AnimManager _animManager;
    Vector2 _direction;

    private void Start()
    {

    }
    private void Update()
    {
        Move(_direction);
        if (_isWaiting)
            WaitPatrol();
        else
            Patrol();
    }
    protected override void Attack()
    {
    
    }
}
