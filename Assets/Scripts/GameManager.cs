using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerPrefab;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (_playerPrefab != null)
            {
                StartCoroutine(DelayedPlayerSpawn());
            }
        }
    }

    private IEnumerator DelayedPlayerSpawn()
    {
        yield return new WaitForSeconds(3);
        int xRandomPoint = Random.Range(-20, 20);
        int zRandomPoint = Random.Range(-20, 20);
        PhotonNetwork.Instantiate(_playerPrefab.name, new Vector3(xRandomPoint, 0, zRandomPoint), Quaternion.identity);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.NickName + " has joined the room!");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " has joined the room " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Room now has " + PhotonNetwork.CurrentRoom.PlayerCount + "/20 players");
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("GameLauncherScene");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
