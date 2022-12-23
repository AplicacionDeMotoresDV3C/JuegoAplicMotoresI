using System.Collections.Generic;
using UnityEngine;

//TPFinal - Rubio, Martín Omar
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instace;
    [SerializeField] GameObject _object;
    [SerializeField] Queue<GameObject> _myQueue;

    void Awake()
    {
        instace = this;
        _myQueue = new Queue<GameObject>();
    }
    
    public GameObject GetNextObject()
    {
        if (_myQueue.Count > 0)
        {
            GameObject e = _myQueue.Dequeue();
            e.SetActive(true);
            return e;
        }
        else
            return Instantiate(_object);
    }

    public void AddToQueue(GameObject newObj)
    {
        _myQueue.Enqueue(newObj);
    }

}
