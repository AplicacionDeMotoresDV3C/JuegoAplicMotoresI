using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TPFinal - Gabriele Peruilh, Guido
public class EnemyBoss : Enemy
{

    [SerializeField] Transform[] teleportWaypoints;
    int randomWaypointToTeleport;
    int lastWaypoint;

    [SerializeField] float _minDistanceToMove;
    [SerializeField] float _teleportCooldown;
    [SerializeField] GameObject _damaging;
    float _cooldownTimerToTeleport;

    bool isAttacking;

    private void Start()
    {
        _player = GameManager.Instance.player.GetComponent<Player>();
        _cooldownTimer = _attackCooldown;
        _cooldownTimerToTeleport = _teleportCooldown;

        lastWaypoint = 0;
        randomWaypointToTeleport = Random.Range(0,teleportWaypoints.Length);

        Health.OnDeath += DeathBehavior;

        myAnim.SetEvent("AttackDamaginActivate", AttackDamaginActivate);
        myAnim.SetEvent("AttackDamagindDesactivate", AttackDamagingDesactivate);
        myAnim.SetEvent("Teleport", TeleportActionInAnimation);
        myAnim.SetEvent("End Attack", endAttacking);

    }

    private void Update()
    {
        if (_player != null)
        {
            _checkDistancePlayer = Vector3.Distance(transform.position, _player.transform.position);
            _cooldownTimer += Time.deltaTime;
            _cooldownTimerToTeleport += Time.deltaTime;

            if (_checkDistancePlayer < _attackDistance)
            {
                if (_attackCooldown < _cooldownTimer)
                {
                    Attack();
                }
                else if (_teleportCooldown <= _cooldownTimerToTeleport)
                {
                    myAnim.SecondaryAniamtion();
                }
            }
            else if (_checkDistancePlayer <= _minDistanceToMove && !isAttacking)
                LookAtPlayer();
            else
                Move(Vector2.zero);
        }
    }

    protected override void Attack()
    {
        isAttacking = true;
        myAnim.AttackAnimation();
        _cooldownTimer = 0;
    }

    void endAttacking()
    {
        isAttacking = false;
    }

    void LookAtPlayer()
    {
        if (transform.position.x < _player.transform.position.x)
            Move(transform.right);
        else
            Move(transform.right * -1);
    }

    void Teleport(Transform newPosition)
    {
        Move(Vector2.zero);
        transform.position = newPosition.transform.position;
        _cooldownTimerToTeleport = 0;
    }


    void DefineRandomWaypoint()
    {
        randomWaypointToTeleport = Random.Range(0, teleportWaypoints.Length);
        if (randomWaypointToTeleport == lastWaypoint)
        {
            DefineRandomWaypoint();
        }
        else
        {
            lastWaypoint = randomWaypointToTeleport;
            return;
        }
    }

    void TeleportActionInAnimation()
    {
        DefineRandomWaypoint();
        Teleport(teleportWaypoints[randomWaypointToTeleport]);
    }

    void AttackDamaginActivate()
    {
        _damaging.SetActive(true);
    }

    void AttackDamagingDesactivate()
    {
        _damaging.SetActive(false);
    }

    protected override void DeathBehavior()
    {
        base.DeathBehavior();
        //GameManager.Instance.Victory();
    }

}
