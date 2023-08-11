using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour, IPunObservable
{
    private float _speed = 5;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            transform.position = (Vector3) stream.ReceiveNext();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    [PunRPC]
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    [PunRPC]
    public void Activate()
    {
        gameObject.SetActive(true);
    }
}
