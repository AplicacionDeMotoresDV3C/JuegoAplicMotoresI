using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Damaging : MonoBehaviour
{
    [SerializeField] int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var entity = collision.GetComponent<Entity>();

        if (entity != null)
        {
            entity.Health.TakeDamage(_damage);
        }
    }
}
