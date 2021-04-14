using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class menuController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject usernameMenu;
    [SerializeField] private GameObject connectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;

    private void Start()
    {
        PhotonNetwork.ConnectToMaster();
        usernameMenu.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected");
    }

    public void ChangeUserNameInput()
    {
        if (UsernameInput.text.Length >= 3)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        usernameMenu.SetActive(false);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }


    public void CreateRoom()
    {
        Debug.Log(CreateGameInput.text);
        if (!string.IsNullOrEmpty(CreateGameInput.text))
        {
            PhotonNetwork.CreateRoom(CreateGameInput.text);
            Debug.Log("Room has been created");
        }
        else
        {
            Debug.Log("No Text found");
            return;
        }
    }


    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Couldn't join room");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
    }

    /* public void joinGame(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    } */

    private void OnJoinedLevel()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }
}
