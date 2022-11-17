using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyPatrol
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _firePoint;
    void Start()
    {
        myAnim.SetEvent("Shot", Shot);
    }

    void Update()
    {

    }

    protected override void Attack()
    {
        throw new System.NotImplementedException();
    }

    protected override void Move(Vector2 direction)
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

    void Shot()
    {
        var b = Instantiate(_bullet);
        b.transform.position = _firePoint.position;
        b.transform.right = transform.right;
    }
}
