using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _nameCreateRoom;
    private void Start()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(100, 900);

        PhotonNetwork.AutomaticallySyncScene = true;

        PhotonNetwork.GameVersion = "1";

        PhotonNetwork.ConnectUsingSettings();
    }

    private void CreateRoom()
    {
      //PhotonNetwork.CreateRoom(_nameCreateRoom, new Photon.Realtime.RoomOptions { MaxPlayers = 4 });
    }
}
    