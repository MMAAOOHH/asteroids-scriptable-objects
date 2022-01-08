using System.Collections.Generic;
using UnityEngine;

public class AsteroidPool : MonoBehaviour
{
    #region SINGLETON
    private static AsteroidPool _instance;
    public static AsteroidPool Instance => _instance;

    private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
        }
        
    #endregion
    
    [SerializeField] private GameObject _prefabToPool;
    [SerializeField] private int _poolStartSize = 20;

    private Queue<GameObject> _objectPool = new Queue<GameObject>();

    private void Start()
    {
        for (var i = 0; i < _poolStartSize; i++)
        {
            GameObject go = Instantiate(_prefabToPool, transform);
            _objectPool.Enqueue(go);
            go.SetActive(false);
        }
    }

    public GameObject Get()
    {
        if (_objectPool.Count > 0)
        {
            GameObject go = _objectPool.Dequeue();
            go.SetActive(true);
            return go;
        }
        else
        {
            GameObject go = Instantiate(_prefabToPool, transform);
            return go;
        }
    }

    public void Return(GameObject go)
    {
        go.SetActive(false);
        _objectPool.Enqueue(go);
    }
}
