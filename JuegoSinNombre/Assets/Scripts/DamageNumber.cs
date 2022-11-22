using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumber : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _myText;
    [SerializeField] Color _playerColor;
    [SerializeField] Color _enemyColor;
    [SerializeField] float _yOffset;
    [SerializeField] float _xOffset;

    public void Display(DamageData data)
    {
        _myText.text = data.value+"";

        if (data.target.Equals("Player"))
            _myText.color = _playerColor;
        else
            _myText.color = _enemyColor;

        Vector3 offset = new Vector2(Random.Range(-_xOffset, _xOffset), _yOffset);
        transform.position = data.position + offset;
    }

    void TurnOff()
    {
        ObjectPool.instace.AddToQueue(gameObject);
        gameObject.SetActive(false);
    }
}
