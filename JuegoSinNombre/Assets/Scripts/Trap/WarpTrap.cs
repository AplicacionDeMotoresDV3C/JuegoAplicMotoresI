using UnityEngine;

//TPFinal - Rubio, Martín Omar
public class WarpTrap : Trap
{
    [SerializeField] Transform _targetPos;
    Entity _target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _target = collision.GetComponent<Entity>();
        if (_target != null)
            Activate();
    }

    protected override void Activate()
    {
        base.Activate();
        _target.enabled = false;
        _target.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _target.transform.position = new Vector3(transform.position.x, _target.transform.position.y, 0);
    }

    void Warp()
    {
        _target.transform.position = _targetPos.position;
        _target.enabled = true;
    }
}
