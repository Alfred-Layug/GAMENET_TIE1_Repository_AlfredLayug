using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _camera;

    [SerializeField] private TextMeshProUGUI _playerNameText;

    private void Start()
    {
        if (photonView.IsMine)
        {
            transform.GetComponent<MovementController>().enabled = true;
            _camera.GetComponent<Camera>().enabled = true;
        }
        else
        {
            transform.GetComponent<MovementController>().enabled = false;
            _camera.GetComponent<Camera>().enabled = false;
        }

        _playerNameText.text = photonView.Owner.NickName;
    }
}
