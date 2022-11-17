using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _lifeTime;

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
        transform.position += transform.right * _speed * Time.deltaTime;
    }
}
