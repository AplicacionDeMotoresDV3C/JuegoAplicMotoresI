using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    [SerializeField] Entity _entity;
    [SerializeField] Animator _myAnim;
    [SerializeField] GameObject _hitbox;

    Dictionary<string, Action> _events;

    private void Start()
    {
        _hitbox.SetActive(false);

        _entity.Health.OnTakeDamage += HitAnimation;
        _entity.Health.OnDeath += DeathAnimation;
    }

    public void AttackAnimation()
    {
        _myAnim.SetTrigger("Attack");
    }
    public void SecondaryAniamtion()
    {
        _myAnim.SetTrigger("Action");
    }
    public void MoveAnimation(float speed)
    {
        _myAnim.SetFloat("Speed", speed);
    }
    public void JumpAnimation()
    {
        _myAnim.SetTrigger("Jump");
    }
    public void RollAnimation()
    {
        _myAnim.SetTrigger("Roll");
    }
    void HitAnimation()
    {
        _myAnim.SetTrigger("Hit");
    }
    void DeathAnimation()
    {
        _myAnim.SetTrigger("Death");
        this.enabled = false;
    }

    public void SetEvent(string key, Action method)
    {
        if (_events.ContainsKey(key)) 
            return;
        else
            _events.Add(key, method);
    }

    public void RemoveEvent(string key)
    {
        if (_events.ContainsKey(key))
            _events.Remove(key);
    }

    public void ExecuteEvent(string key)
    {
        if (_events.ContainsKey(key))
            _events[key]();
    }
}
