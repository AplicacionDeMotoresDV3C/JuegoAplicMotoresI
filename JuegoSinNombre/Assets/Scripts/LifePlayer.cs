using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LifePlayer : MonoBehaviour
{
    public Image _lifeBar;
    float _life = 100;
    [SerializeField] Entity _entity;

    private void Start()
    {
        _entity = GetComponent<Entity>();
    }
    void Update()
    {
        _life = Mathf.Clamp(_life, 0, 100);

        _lifeBar.fillAmount = _life / 100;
    }
}
