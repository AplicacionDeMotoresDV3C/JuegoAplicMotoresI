using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] protected float _attackCooldown;
    [SerializeField] protected float _cooldownTimer;
    [SerializeField] protected float _attackDistance;
    [SerializeField] protected float _checkDistancePlayer;
}
