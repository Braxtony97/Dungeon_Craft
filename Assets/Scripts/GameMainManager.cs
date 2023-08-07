using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMainManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Text _textUI;

    private void Start()
    {
        Vector2 _playerPosition = new Vector2((Random.Range(-5f, 5f)), (Random.Range(-4f, 4f)));
        PhotonNetwork.Instantiate(_player.name, _playerPosition, Quaternion.identity);
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");
        _textUI.text = "Left Room";
        SceneManager.LoadScene(1);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("{0} entered room", newPlayer.NickName);
        _textUI.text = newPlayer.NickName + " entered room";
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("{0} left room", otherPlayer.NickName);
        _textUI.text = otherPlayer.NickName + " left room";
    }


}
