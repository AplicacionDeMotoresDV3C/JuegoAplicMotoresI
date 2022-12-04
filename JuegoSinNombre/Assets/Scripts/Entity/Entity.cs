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
        _health.OnTakeDamage += ShowDamage;
        myAnim.SetEvent("InvunerableOn", InvunerableOn);
        myAnim.SetEvent("InvunerableOff", InvunerableOff);
        Health.OnDeath += DeathBehavior;
    }

    protected abstract void Attack();
    protected abstract void Move(Vector2 direction);

    protected virtual void DeathBehavior()
    {
        _rb.velocity = Vector2.zero;
        _rb.isKinematic = true;

        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;
    }

    void InvunerableOn()
    {
        Health.isInvunerable = true;
    }

    void InvunerableOff()
    {
        Health.isInvunerable = false;
    }

    void ShowDamage(DamageData data)
    {
        var o = ObjectPool.instace.GetNextObject();
        o.GetComponent<DamageNumber>().Display(data);
    }
}
