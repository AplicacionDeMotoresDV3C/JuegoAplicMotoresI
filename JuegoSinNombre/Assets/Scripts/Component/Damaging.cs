using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Damaging : MonoBehaviour
{
    [SerializeField] int _minDamage;
    [SerializeField] int _maxDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var entity = collision.GetComponent<Entity>();

        if (entity != null)
            InfictDamage(entity);
    }

    void InfictDamage(Entity entity)
    {
        var dam = _minDamage >= _maxDamage ? _minDamage : Random.Range(_minDamage, _maxDamage + 1);
        var tar = LayerMask.LayerToName(entity.gameObject.layer);
        var pos = entity.transform.position;
        var data = new DamageData(dam, tar, pos);

        entity.Health.TakeDamage(data);
    }
}
