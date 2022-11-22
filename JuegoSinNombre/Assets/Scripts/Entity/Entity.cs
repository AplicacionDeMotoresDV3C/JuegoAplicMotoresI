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
        myAnim.SetEvent("InvunerableOff", InvunerableOff);
    }

    protected abstract void Attack();
    protected abstract void Move(Vector2 direction);

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
