using TMPro;
using UnityEngine;

//TPFinal - Rubio, Martín Omar
public class DamageNumber : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _myText;
    [SerializeField] Color _playerColor;
    [SerializeField] Color _enemyColor;
    [SerializeField] Color _trapColor;
    [SerializeField] float _yOffset;
    [SerializeField] float _xOffset;

    public void Display(DamageData data)
    {
        _myText.text = data.value+"";

        switch (data.source)
        {
            case DamageSource.Player:
                _myText.color = _playerColor;
                break;
            case DamageSource.Enemy:
                _myText.color = _enemyColor;
                break;
            case DamageSource.Trap:
                _myText.color = _trapColor;
                break;
            default:
                break;
        }

        Vector3 offset = new Vector2(Random.Range(-_xOffset, _xOffset), _yOffset);
        transform.position = data.position + offset;
    }

    void TurnOff()
    {
        ObjectPool.instace.AddToQueue(gameObject);
        gameObject.SetActive(false);
    }
}

