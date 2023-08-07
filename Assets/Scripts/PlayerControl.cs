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
    [SerializeField] private WeaponBehaviour _weaponBehaviour;
    [SerializeField] private ShootBehaviour _shootBehaviour;
    [SerializeField] private float _timeReloadShot;
    private float _timeBetweenShots;

    private void Start()
    { 
        if (!_photonView.IsMine)
        {
            _spriteRenderer.sprite = _otherPlayerSprite;
        }
 
    }

    void FixedUpdate()
    {
        if (_photonView.IsMine )
        {
            if (ControlTypeValue == ControlType.Android)
            {
                _moveBehaviour.MoveJoystick();
                _weaponBehaviour.FollowingAndroid();
                if (_weaponBehaviour.TouchJoystick())
                {
                    if (_timeBetweenShots <= 0)
                    {
                        _shootBehaviour.ThrowShuriken();
                        _timeBetweenShots = _timeReloadShot;
                    }
                    else _timeBetweenShots -= Time.deltaTime;
                }
            }
            
            else if (ControlTypeValue == ControlType.PC)
            {
                _moveBehaviour.MovePC();
                _weaponBehaviour.FollowingPC();
                if (Input.GetMouseButtonDown(0))
                {
                    _shootBehaviour.ThrowShuriken();
                }
            }
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
}

