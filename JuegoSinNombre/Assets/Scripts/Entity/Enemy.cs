using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] protected float _attackCooldown;
    protected float _cooldownTimer;
    [SerializeField] protected float _attackDistance;
    protected float _checkDistancePlayer;
    protected Player _player;


    //Rubio, Martín Omar
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
