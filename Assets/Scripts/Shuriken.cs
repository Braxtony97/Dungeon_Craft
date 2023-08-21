using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shuriken : MonoBehaviour, IPunObservable
{
    private float _speed = 5;
    [SerializeField] private Text _textUI;

    private void Awake()
    {
        _textUI = GameObject.Find("TextDebug").GetComponent<Text>();
    }

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PhotonView _photonView = collision.GetComponent<PhotonView>();
            if (_photonView != null && _photonView.IsMine)
            {
                Debug.Log("Me");
                _textUI.text = "Me";
            }
            else if (_photonView != null)
            {
                Debug.Log("Enemy");
                _textUI.text = "Enemy";
            }
        }
    }
}
