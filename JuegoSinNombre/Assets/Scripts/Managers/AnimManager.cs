using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    [SerializeField] Animator _myAnim;
    [SerializeField] GameObject _hitbox;

    private void Start()
    {
        _hitbox.SetActive(false);
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
    public void HitAnimation()
    {
        _myAnim.SetTrigger("Hit");
    }
    public void DeathAnimation()
    {
        _myAnim.SetTrigger("Death");
        this.enabled = false;
    }
    public void JumpAnimation()
    {
        _myAnim.SetTrigger("Jump");
    }
    public void RollAnimation()
    {
        _myAnim.SetTrigger("Roll");
    }
    public void EventHitBox(bool enable)
    {
        _hitbox?.SetActive(enabled);
    }
    public void EventInstanceBullet(Bullet bullet)
    {
        Debug.Log("Shot");
    }
}
