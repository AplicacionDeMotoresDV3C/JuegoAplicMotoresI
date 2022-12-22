using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] protected Animator _myAnim;
    [SerializeField] bool _isResetOnCheckpoint;

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
        _myAnim.SetTrigger("Activate");
    }

    protected virtual void Reset(CheckpointStruct checpointData)
    {

        _myAnim.Rebind();
    }

    private void OnDestroy()
    {
        if (_isResetOnCheckpoint && GameManager.Instance != null)
            GameManager.Instance.OnCheckPointLoad -= Reset;
    }
}
