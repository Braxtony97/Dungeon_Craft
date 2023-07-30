using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    private void Update()
    {
        if (!_photonView.IsMine) return;
        if (Input.GetKey(KeyCode.A)) transform.Translate(-Time.deltaTime * 5f, 0f, 0f);
        if (Input.GetKey(KeyCode.D)) transform.Translate(Time.deltaTime * 5f, 0f, 0f);
    }
}
