
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    public static PhotonLobby lobby;
    #region Singleton
    private static PhotonLobby _instance = null;
    public static PhotonLobby Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PhotonLobby>();
            }
            return _instance;
        }
    }
    #endregion

    public GameObject leaveLobbyButton;
    public GameObject createRoomButton;
    public GameObject leaveRoomButton;
    public GameObject joinRoomButton;
    public GameObject toggleRoomButton;

    public Dropdown dropdown;
    public Text lobbyText;
    public Text roomText;
    public Text roomToggleText;

    public List<RoomInfo> roomList;


    private void Start()
    {
        roomList = new List<RoomInfo>();
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has conencted to the master photon server");
        createRoomButton.SetActive(true);
        dropdown.options.Clear();
        if (roomList.Count > 0)
        {
            joinRoomButton.SetActive(true);
        }
        if (!PhotonNetwork.InLobby)
        {
            lobbyText.text = "Leave Lobby";
            PhotonNetwork.JoinLobby();
        }
        ToggleInRoomButton(false);
        if (roomList.Count > 0)
        {
            joinRoomButton.SetActive(true);
        }
        Debug.Log($"Number of rooms :{PhotonNetwork.CountOfRooms}");
    }


    public void OnCreateRoomButtonClicked()
    {
        Debug.Log("Battle Button Clicked");
        ToggleInRoomButton();
        CreateRoom();
    }

    private void ToggleInRoomButton(bool InRoom = true)
    {
        createRoomButton.SetActive(!InRoom);
        joinRoomButton.SetActive(!InRoom);
        leaveRoomButton.SetActive(InRoom);
        dropdown.gameObject.SetActive(!InRoom);
        toggleRoomButton.SetActive(InRoom);
        leaveLobbyButton.SetActive(!InRoom);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random room but failed, no room available.");
        CreateRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("You joined a room.");
        ToggleInRoomButton();
        roomText.text = $"Leave: {PhotonNetwork.CurrentRoom.Name}";
    }

    private static void CreateRoom()
    {
        Debug.Log("Trying to create new room");
        int randomRoomName = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        PhotonNetwork.CreateRoom($"Room {randomRoomName}", roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a random room but failed, room with same name already exist.");
        CreateRoom();
    }

    public void OnLeaveRoomButtonClicked()
    {
        ToggleInRoomButton(false);
        roomText.text = "Joining...";
        PhotonNetwork.LeaveRoom();
    }

    public void OnJoinRoomButtonClicked()
    {
        if (dropdown.options.Count == 0)
        {
            Debug.Log("No Rooms");
            return;
        }
        ToggleInRoomButton();
        var data = dropdown.options[dropdown.value].text;
        PhotonNetwork.JoinRoom(data);
    }

    public void OnLobbyButtonClicked()
    {
        if (PhotonNetwork.InLobby)
        {
            Debug.Log("Leave Lobby");
            lobbyText.text = "Join Lobby";
            roomList.Clear();
            dropdown.ClearOptions();
            ToggleInLobby(false);
            PhotonNetwork.LeaveLobby();
        }
        else
        {
            Debug.Log("Join Lobby");
            ToggleInLobby();
            lobbyText.text = "Leave Lobby";
            PhotonNetwork.JoinLobby();
        }
    }
    public void ToggleInLobby(bool InLobby = true)
    {
        createRoomButton.SetActive(InLobby);
        joinRoomButton.SetActive(InLobby);
        dropdown.gameObject.SetActive(InLobby);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        base.OnRoomListUpdate(roomList);
        Debug.Log($"List update {roomList.Count}");
        this.roomList = roomList;

        foreach (var room in roomList)
        {
            var data = new Dropdown.OptionData() { text = room.Name };
            if (room.RemovedFromList || !room.IsOpen)
            {
                var oldRoom = dropdown.options.Find(x => x.text == data.text);
                dropdown.options.Remove(oldRoom);
            }
            else
            {
                if (!dropdown.options.Exists(x => x.text == data.text))
                {
                    dropdown.options.Add(data);
                }
            }
        }
        dropdown.RefreshShownValue();
        if (roomList.Count > 0)
        {
            joinRoomButton.SetActive(true);
        }
    }

    public void OnToggleRoomButtonClicked()
    {
        if (PhotonNetwork.CurrentRoom.IsOpen)
        {
            roomToggleText.text = "Open Room";
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        else
        {
            roomToggleText.text = "Close Room";
            PhotonNetwork.CurrentRoom.IsOpen = true;
        }
    }
} // Class PhotonLobby
