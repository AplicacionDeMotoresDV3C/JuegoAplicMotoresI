using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] HealthComponent _health;
    public HealthComponent Health { get { return _health; } }

    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected float speed;
    [SerializeField] protected AnimManager myAnim;

    private void Awake()
    {
        _health.SetHealth();
        Health.OnTakeDamage += myAnim.HitAnimation;
       Health.OnDeath += myAnim.DeathAnimation;
    }

    protected abstract void Attack();
    protected abstract void Move(Vector2 direction);
   
}
