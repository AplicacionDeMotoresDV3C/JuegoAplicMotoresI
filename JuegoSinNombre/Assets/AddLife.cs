using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basualdo sebastian
public class AddLife : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player _player = collision.gameObject.GetComponent<Player>();
        if (collision.gameObject.CompareTag("Player"))
        {
            var life = _player.Health.GetHealth();
            life++;
            if (_player.Health.GetHealth() < _player.Health.GetMaxHeal())
            {
                _player.Health.Heal(life);
                Destroy(gameObject);
            }
        }
    }
}
