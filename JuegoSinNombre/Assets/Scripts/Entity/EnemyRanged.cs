using UnityEngine;


//Rubio, Martín Omar
public class EnemyRanged : EnemyPatrol 
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _firePoint;

    void Start()
    {
        myAnim.SetEvent("Shot", Shot);
        _player = GameManager.Instance.player.GetComponent<Player>();
    }

    void Update()
    {
        _checkDistancePlayer = Vector3.Distance(_player.transform.position, transform.position);

        if ( _checkDistancePlayer < _attackDistance)
            Attack();
        else if (_isWaiting)
            WaitPatrol();
        else
            Patrol();
    }

    protected override void Attack()
    {
        Move(Vector2.zero);
        _isWaiting = true;

        if (_player.transform.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        _cooldownTimer += Time.deltaTime;

        if (_attackCooldown < _cooldownTimer)
        {
            myAnim.AttackAnimation();
            _cooldownTimer = 0;
        }
    }

    void Shot()
    {
        var b = Instantiate(_bullet).GetComponent<Bullet>();
        b.transform.position = _firePoint.position;
        b.SetDirection(new Vector3(transform.localScale.x,0,0));
    }
}
