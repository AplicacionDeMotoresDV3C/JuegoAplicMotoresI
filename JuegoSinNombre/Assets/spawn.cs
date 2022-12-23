using UnityEngine;


//basualdo sebastian
public class spawn : MonoBehaviour
{
    [SerializeField] GameObject _potion;
    [SerializeField] MeleeEnemy _melee;
    [SerializeField] float _time;
    [SerializeField] float _maxTime = 0.5f;
    int random;
    public bool spawnDrop = false;
    private void Start()
    {
        _melee.Health.OnDeath += Spawn;
    }
    private void Update()
    {
        if (spawnDrop)
        {
            _time += Time.deltaTime;
            if (_time >= _maxTime && spawnDrop)
            {
                SpawnDrop();
            }
        }
    }
    void Spawn()
    {
        spawnDrop = true;
    }
    public void SpawnDrop()
    {

        random = Random.Range(0, 2);
        if (random == 0)
        {
            Instantiate(_potion, transform.position, Quaternion.identity);
        }
        _time = 0;
        spawnDrop = false;

    }
    private void OnDestroy()
    {
        _melee.Health.OnDeath -= SpawnDrop;
    }
}
