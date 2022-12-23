using UnityEngine;

//TPFinal - basualdo sebastian
public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _moveRight;
    [SerializeField] float _smoothing;
    Vector3 _playerPos;

    private void Update()
    {
        _playerPos = new Vector3(_player.transform.position.x, _player.transform.position.y, transform.position.z);

        if (_player.transform.localScale.x == _moveRight)
        {
            _playerPos = new Vector3(_playerPos.x + _player.transform.localScale.x * _moveRight, _playerPos.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, _playerPos, _smoothing * Time.deltaTime);
    }
}
