using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] HealthComponent _health;
    public HealthComponent Health { get { return _health; } }

    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected float speed;
    [SerializeField] protected AnimManager myAnim;


    //TPFinal - Rubio, Mart�n Omar
    private void Awake()
    {
        _health.StartingHealth();
        _health.OnTakeDamage += ShowDamage;
        myAnim.SetEvent("InvunerableOn", InvunerableOn);
        myAnim.SetEvent("InvunerableOff", InvunerableOff);
        Health.OnDeath += DeathBehavior;
    }

    protected abstract void Attack();
    protected abstract void Move(Vector2 direction);


    //TPFinal - Rubio, Mart�n Omar
    protected virtual void DeathBehavior()
    {
        _rb.velocity = Vector2.zero;
        _rb.isKinematic = true;

        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;
    }

    //TPFinal - Gabriele Peruilh, Guido
    void InvunerableOn()
    {
        Health.isInvunerable = true;
    }
    //TPFinal - Gabriele Peruilh, Guido
    void InvunerableOff()
    {
        Health.isInvunerable = false;
    }


    //TPFinal - Rubio, Mart�n Omar
    void ShowDamage(DamageData data)
    {
        var o = ObjectPool.instace.GetNextObject();
        o.GetComponent<DamageNumber>().Display(data);
    }
}
