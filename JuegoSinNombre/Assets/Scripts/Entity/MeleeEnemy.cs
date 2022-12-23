using UnityEngine;


//basualdo sebastian
public class MeleeEnemy : EnemyPatrol
{
    [SerializeField] GameObject _damaging;
    [SerializeField] float _foolowPlayar;

    private void Start()
    {
        _player = GameManager.Instance.player.GetComponent<Player>();

        myAnim.SetEvent("AttackHeatBoxPlay", AttackHeatBoxPlay);
        myAnim.SetEvent("AttackHeatBoxExit", AttackHeatBoxExit);
    }
    private void Update()
    {
        if (_player.transform.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        checkDistanceFromPlayer();
        if(_checkDistancePlayer <= _attackDistance)
        {
            Attack();         
        }
        else if(_checkDistancePlayer <= _foolowPlayar)
        {
            FollowPlayer();
        }
        else if (_isWaiting)
            WaitPatrol();
        else
            Patrol();
    }
    void FollowPlayer()
    {
        Move(Vector2.zero);
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);       
    }
    void checkDistanceFromPlayer()
    {
        _checkDistancePlayer = Vector2.Distance(transform.position, _player.transform.position);
    }
    protected override void Attack()
    {
        Move(Vector2.zero);
        myAnim.AttackAnimation();
    }
    void AttackHeatBoxPlay()
    {
        _damaging.SetActive(true);
    }
    void AttackHeatBoxExit()
    {
        _damaging.SetActive(false);
    }
}
