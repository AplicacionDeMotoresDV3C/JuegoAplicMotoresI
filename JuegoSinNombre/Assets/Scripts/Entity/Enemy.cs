using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] protected float attackCooldown;
    protected float cooldownTimer;
    [SerializeField] protected float attackDistance;
    protected float checkDistancePlayer;
}
