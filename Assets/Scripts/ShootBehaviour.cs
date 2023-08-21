using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ShootBehaviour : MonoBehaviourPunCallbacks
{
    private ShurikenPoolObject _shurikenPool;
    [SerializeField] private Transform _pointer;

    public void Start()
    {
        _shurikenPool = GameObject.Find("GameMainManager").GetComponent<ShurikenPoolObject>();
    }
    public void ThrowShuriken()
    {
        GameObject Shuriken = _shurikenPool.CreateShuriken(_pointer, _pointer.transform.rotation);
        /*Shuriken.transform.position = _pointer.transform.position;
        Shuriken.transform.rotation = _pointer.transform.rotation; // что бы повороты пойнтора тоже учитывались */
    }
}
