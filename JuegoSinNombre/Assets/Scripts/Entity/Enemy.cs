using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected float cooldownTimer;
    [SerializeField] protected float attackDistance;
    [SerializeField] protected float checkDistancePlayer;
}
