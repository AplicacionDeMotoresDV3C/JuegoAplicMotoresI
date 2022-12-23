using System;
using System.Collections.Generic;
using UnityEngine;

//TPFinal - Rubio, Martín Omar
public class AnimManager : MonoBehaviour
{
    [SerializeField] Entity _entity;
    [SerializeField] Animator _myAnim;
    Dictionary<string, Action> _events = new Dictionary<string, Action>();

    private void Start()
    {
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
        _myAnim.SetFloat("Speed", Mathf.Abs(speed));
    }
    public void JumpAnimation()
    {
        _myAnim.SetTrigger("Jump");
    }
    public void RollAnimation()
    {
        _myAnim.SetTrigger("Roll");
    }
    public void HitAnimation(DamageData data)
    {
        _myAnim.SetTrigger("Hit");
    }
    public void ShieldAnimation(bool isShield)
    {
        _myAnim.SetBool("Shield",isShield);
    }
    public void DeathAnimation()
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
