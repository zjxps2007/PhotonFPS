using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomNameInputField;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private TMP_Text roomNameText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings(); // 마스터 서버를 연결
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        Debug.Log("Joined Lobby");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }

        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed : " + message;
        MenuManager.Instance.OpenMenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }
}