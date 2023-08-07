using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    private ShurikenPoolObject _shurikenPool;
    [SerializeField] private Transform _pointer;

    public void Start()
    {
        _shurikenPool = GameObject.Find("GameMainManager").GetComponent<ShurikenPoolObject>();
    }
    public void ThrowShuriken()
    {
        Shuriken Shuriken = _shurikenPool.CreateShuriken();
        Shuriken.transform.position = _pointer.transform.position;
        Shuriken.transform.rotation = _pointer.transform.rotation; // что бы повороты пойнтора тоже учитывались
    }
}
