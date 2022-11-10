using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyPatrol
{
    [SerializeField] GameObject _bullet;
    void Start()
    {

    }

    void Update()
    {

    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    protected override void Patrol()
    {
        throw new System.NotImplementedException();
    }

    protected override void WaitPatrol()
    {
        throw new System.NotImplementedException();
    }
}
