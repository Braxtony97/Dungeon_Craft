using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenPoolObject : MonoBehaviour
{
    [SerializeField] private int _poolCount = 30;
    [SerializeField] private bool _autoExpand = false; 
    [SerializeField] private Shuriken _shurikenPrefab;
    private PoolMono<Shuriken> _pool;

    private void Start()
    {
        _pool = new PoolMono<Shuriken> (_shurikenPrefab, _poolCount, transform); 
        _pool.AutoExpand = _autoExpand;
    }

    public Shuriken CreateShuriken()
    {
        Shuriken Shuriken = _pool.GetFreeElement();
        return Shuriken;
    }



}
