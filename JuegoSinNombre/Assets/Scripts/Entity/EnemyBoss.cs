using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    //public List<Transform> teleportWaypoints = new List<Transform>();
    [SerializeField] Transform[] teleportWaypoints;
    int randomWaypointToTeleport;
    int lastWaypoint;

    [SerializeField] float _minDistanceToMove;
    [SerializeField] float _teleportCooldown;
    float _cooldownTimerToTeleport;
    bool _isWaitingToTeleport;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _cooldownTimer = _attackCooldown;
        _cooldownTimerToTeleport = _teleportCooldown;
        lastWaypoint = 0;
        randomWaypointToTeleport = Random.Range(0,teleportWaypoints.Length);
    }

    private void Update()
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
            else if (_teleportCooldown <= _cooldownTimerToTeleport) //Deberia poder hacer un teleport  atras del otro
            {
                myAnim.SecondaryAniamtion();
            }
        }
        //else if (_checkDistancePlayer <= _minDistanceToMove)
        //    LookAtPlayer();
        else
            Move(Vector2.zero);
    }

    protected override void Attack()
    {
        Move(Vector2.zero);
        myAnim.AttackAnimation();
        _cooldownTimer = 0;
    }

    void AttackFinishAnimation()
    {
        _cooldownTimer = 0;

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
        //_cooldownTimerToTeleport = 0;
    }

    void TeleportFinishAnimation()
    {
        Debug.Log("Animacion teleport terminada");
        Move(Vector2.zero);
        _cooldownTimerToTeleport = _teleportCooldown;
    }

    void TeleportInitialAnimation()
    {
        Debug.Log("Animacion comienza");
        Move(Vector2.zero);
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
            return;
    }

    void TeleportActionInAnimation()
    {
        DefineRandomWaypoint();
        Teleport(teleportWaypoints[randomWaypointToTeleport]);
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



}
