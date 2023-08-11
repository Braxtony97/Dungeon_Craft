using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.Pool;

public class ShurikenPoolObject : MonoBehaviourPunCallbacks
{
    [SerializeField] private int _poolCount = 30;
    [SerializeField] private bool _autoExpand = false; 
    [SerializeField] private GameObject _shurikenPrefab;
    [SerializeField] private PhotonView _photonView;

    private float _lifeTimeShuriken = 2f;
    private List<GameObject> _shurikenPool;

    private void Start()
    {
        InstantiatePool();
    }

    private void InstantiatePool()
    {
        _shurikenPool = new List<GameObject>();

        for (int i = 0; i <_poolCount; i++)
        {
            GameObject _shuriken = PhotonNetwork.Instantiate(_shurikenPrefab.name, transform.position, Quaternion.identity);
            _shuriken.GetPhotonView().RPC("Deactivate", RpcTarget.AllBuffered);
            _shurikenPool.Add(_shuriken); 
        }
    }

    public GameObject CreateShuriken(Transform Position, Quaternion Rotation)
    {
        foreach ( GameObject Shuriken in _shurikenPool)
        {
            if (!Shuriken.activeInHierarchy)
            {
                Shuriken.transform.position = Position.transform.position;
                Shuriken.transform.rotation = Rotation;
                Shuriken.GetPhotonView().RPC("Activate", RpcTarget.AllBuffered);
                StartCoroutine(DeactivateShuriken(Shuriken));
                return Shuriken;
            }
        }
        return null;
    }

    IEnumerator DeactivateShuriken(GameObject Shuriken)
    {

        yield return new WaitForSeconds(_lifeTimeShuriken);

        Shuriken.GetPhotonView().RPC("Deactivate", RpcTarget.AllBuffered);
    }
}
