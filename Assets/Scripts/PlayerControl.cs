using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IPunObservable 
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _otherPlayerSprite;
    private float _speedMove = 5f;
    private Vector2 _directionLook;

    private void Start()
    {
        if (!_photonView.IsMine) _spriteRenderer.sprite = _otherPlayerSprite;
    }


    private void Update()
    {
        if (_photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _directionLook = Vector2.left;
                transform.Translate (Time.deltaTime * _speedMove * _directionLook); 

            }
            if (Input.GetKey(KeyCode.D))
            {
                _directionLook = Vector2.right;
                transform.Translate(Time.deltaTime * _speedMove * _directionLook);

            }
            if (Input.GetKey(KeyCode.W))
            {
                _directionLook = Vector2.up;
                transform.Translate(Time.deltaTime * _speedMove * _directionLook);

            }
            if (Input.GetKey(KeyCode.S))
            {
                _directionLook = Vector2.down;
                transform.Translate(Time.deltaTime * _speedMove * _directionLook);

            }
        }

        if (_directionLook == Vector2.left) _spriteRenderer.flipX = false;
        else if (_directionLook == Vector2.right) _spriteRenderer.flipX = true;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) 
        {
            stream.SendNext(_directionLook); 
        }
        else if (stream.IsReading) 
        {
            _directionLook = (Vector2) stream.ReceiveNext();
        }
    }
}
