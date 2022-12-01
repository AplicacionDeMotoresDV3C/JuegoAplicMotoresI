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

        Destroy(gameObject, 2.5f);

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

}
