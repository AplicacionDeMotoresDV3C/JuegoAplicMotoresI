using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] protected Animator _myAnim;
    [SerializeField] bool _isResetOnCheckpoint;
    bool _isActive = false;

    private void Start()
    {
        if (_isResetOnCheckpoint)
            GameManager.Instance.OnCheckPointLoad += Reset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Activate();
    }

    protected virtual void Activate()
    {
        if (_isActive) return;

        _myAnim.SetTrigger("Activate");
        _isActive = true;
    }

    protected virtual void Reset(CheckpointStruct checpointData)
    {
        if (_isActive)
        {
            _myAnim.Rebind();
            _isActive = false;
        }
    }

    private void OnDestroy()
    {
        if (_isResetOnCheckpoint && GameManager.Instance != null)
            GameManager.Instance.OnCheckPointLoad -= Reset;
    }
}
