using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class MeleeEnemy : EnemyPatrol
{

    [SerializeField] AnimManager _animManager;
    Vector2 _direction;
    [SerializeField] GameObject _damaging;


    private void Start()
    {
        _player = GameManager.Instance.player.GetComponent<Player>();

        myAnim.SetEvent("AttackHeatBoxPlay", AttackHeatBoxPlay);
        myAnim.SetEvent("AttackHeatBoxExit", AttackHeatBoxExit);
    }
    private void Update()
    {
        _checkDistancePlayer = Vector2.Distance(transform.position, _player.transform.position);

        if (_checkDistancePlayer <= _attackDistance)
            Attack();
        else if (_isWaiting)
            WaitPatrol();
        else
            Patrol();
    }
    protected override void Attack()
    {
        Move(Vector2.zero);
        myAnim.AttackAnimation();
    }
    void AttackHeatBoxPlay()
    {
        _damaging.SetActive(true);
    }
    void AttackHeatBoxExit()
    {
        _damaging.SetActive(false);
    }
}
