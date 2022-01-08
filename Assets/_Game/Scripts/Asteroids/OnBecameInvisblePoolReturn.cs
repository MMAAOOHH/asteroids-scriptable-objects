using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBecameInvisblePoolReturn : MonoBehaviour
{
    private AsteroidPool _pool;

    private void Start()
    {
        _pool = AsteroidPool.Instance;
    }

    private void OnBecameInvisible()
    {
        _pool.Return(gameObject);
    }
}
