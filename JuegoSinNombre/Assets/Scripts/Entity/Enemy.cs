using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] protected float _attackCooldown;
    protected float _cooldownTimer;
    [SerializeField] protected float _attackDistance;
    protected float _checkDistancePlayer;
    protected Player _player;
}
