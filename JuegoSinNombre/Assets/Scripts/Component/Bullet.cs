using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _lifeTime;
    Vector3 _direction;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 value)
    {
        _direction = value.normalized;

        var r = transform.localScale;
        r.x = _direction.x;
        transform.localScale = r;
    }
}
