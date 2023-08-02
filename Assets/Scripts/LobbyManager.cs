using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _nameCreateRoom;
    [SerializeField] private InputField _nameJoinRoom;
    private void Start()
    {
        PhotonNetwork.NickName = "Player " + Random.Range(100, 999);
        Debug.Log("Player's name: " + PhotonNetwork.NickName);

    }

    public void CreateRoom()
    {
      PhotonNetwork.CreateRoom(_nameCreateRoom.text, new Photon.Realtime.RoomOptions { MaxPlayers = 4 });
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created!");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_nameJoinRoom.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joinde the room: " + _nameCreateRoom.text);
        PhotonNetwork.LoadLevel("Game");
    }
}
    