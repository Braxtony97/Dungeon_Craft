using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IPunObservable
{
    public enum ControlType {PC, Android};
    public ControlType ControlTypeValue;

    [SerializeField] private PhotonView _photonView;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _otherPlayerSprite;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] MoveBehaviour _moveBehaviour;
    [SerializeField] private IWeapon _weapon;
    [SerializeField] private Transform _pointer;
    private ShurikenPoolObject _shurikenPool;

    private void Start()
    {
        _shurikenPool = GameObject.Find("GameMainManager").GetComponent<ShurikenPoolObject>();

        if (!_photonView.IsMine)
        {
            _spriteRenderer.sprite = _otherPlayerSprite;
        }
 
    }


    private void Update()
    {

    }

    void FixedUpdate()
    {
        if (_photonView.IsMine )
        {
            if (ControlTypeValue == ControlType.Android)
            {
                _moveBehaviour.MoveJoystick();
            }
            
            else if (ControlTypeValue == ControlType.PC)
            {
                _moveBehaviour.MovePC();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
            if (stream.IsWriting) 
            {
                stream.SendNext(_moveBehaviour.DirectionLook); 
            }
            else if (stream.IsReading) 
            {
                _moveBehaviour.DirectionLook = (bool) stream.ReceiveNext();
            }
    }

    public void Fire()
    {
        Shuriken Shuriken = _shurikenPool.CreateShuriken();
        Shuriken.transform.position = _pointer.transform.position;
        Shuriken.transform.rotation = _pointer.transform.rotation; // что бы повороты пойнтора тоже учитывались
    }
}

