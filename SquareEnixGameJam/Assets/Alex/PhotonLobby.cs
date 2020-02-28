
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks
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
    public GameObject mainPanel;
    public GameObject secondPanel;

    public Button loadGameBtn;

    public Text lobbyText;
    public Text roomText;
    public Text playerText;
    public Text connectingText;
    public Dropdown dropdown;
    private const string GameVersion = "0.2";

    private void Start()
    {
        secondPanel.SetActive(false);
    }



    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has conencted to the master photon server");
        createRoomButton.SetActive(true);
        dropdown.options.Clear();
        mainPanel.SetActive(false);
        secondPanel.SetActive(true);
        if (!PhotonNetwork.InLobby)
        {
            lobbyText.text = "Leave Lobby";
            PhotonNetwork.JoinLobby();
        }

        Debug.Log($"Number of rooms :{PhotonNetwork.CountOfRooms}");
    }

    

    public override void OnJoinedRoom()
    {
        Debug.Log("You joined a room.");
        ToggleInRoomButton();
        roomText.text = $"Leave: {PhotonNetwork.CurrentRoom.Name}";
        playerText.text = PhotonNetwork.LocalPlayer.NickName;
        foreach (var player in PhotonNetwork.PlayerListOthers)
        {
            playerText.text += $"\n{player.NickName}";
        }

        PhotonNetwork.CurrentRoom.IsOpen = PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers;
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            loadGameBtn.gameObject.SetActive(true);
        }
    }

    public override void OnLeftRoom()
    {
        loadGameBtn.gameObject.SetActive(false);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        roomText.text = message;
    }

    [PunRPC]
    public void LoadLevel()
    {
        PhotonNetwork.LoadLevel("PlayerLobby");
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        playerText.text += $"\n{newPlayer.NickName}";
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            loadGameBtn.gameObject.SetActive(true);
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        playerText.text = PhotonNetwork.LocalPlayer.NickName;
        foreach (var player in PhotonNetwork.PlayerListOthers)
        {
            playerText.text += $"\n{player.NickName}";
        }
        PhotonNetwork.CurrentRoom.IsOpen = PhotonNetwork.CurrentRoom.PlayerCount < PhotonNetwork.CurrentRoom.MaxPlayers;
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            loadGameBtn.gameObject.SetActive(true);
        }
        else
        {
            loadGameBtn.gameObject.SetActive(false);
        }
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


    private void ToggleRoomBtnDrop(bool on = true)
    {
        joinRoomButton.SetActive(on);
        dropdown.gameObject.SetActive(on);
    }

    
    public void ToggleInLobby(bool InLobby = true)
    {
        createRoomButton.SetActive(InLobby);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"List update {roomList.Count}");

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
        if (dropdown.options.Count > 0)
        {
            ToggleRoomBtnDrop();
        }
        else
        {
            ToggleRoomBtnDrop(false);
        }
    }

    public void OnToggleRoomButtonClicked()
    {
        if (PhotonNetwork.CurrentRoom.IsOpen)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        else
        {
            PhotonNetwork.CurrentRoom.IsOpen = true;
        }
    }

    private void ToggleInRoomButton(bool InRoom = true)
    {
        createRoomButton.SetActive(!InRoom);
        leaveRoomButton.SetActive(InRoom);
        leaveLobbyButton.SetActive(!InRoom);
        playerText.text = "";
        playerText.gameObject.SetActive(InRoom);
    }

    // --- Buttons methods ---

    public void OnConnectButtonClicked()
    {
        connectingText.text = "Searching...";
        PhotonNetwork.GameVersion = GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnLobbyButtonClicked()
    {
        if (PhotonNetwork.InLobby)
        {
            Debug.Log("Leave Lobby");
            lobbyText.text = "Join Lobby";
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

    public void OnCreateRoomButtonClicked()
    {
        Debug.Log("Battle Button Clicked");
        ToggleRoomBtnDrop(false);
        ToggleInRoomButton();
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
        ToggleRoomBtnDrop(false);
        var data = dropdown.options[dropdown.value].text;
        PhotonNetwork.JoinRoom(data);
    }

    public void OnLoadGameButtonClicked()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        photonView.RPC("LoadLevel", RpcTarget.AllViaServer);
    }
} // Class PhotonLobby
