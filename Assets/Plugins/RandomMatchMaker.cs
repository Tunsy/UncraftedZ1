using UnityEngine;
using System.Collections;
using Photon;

public class RandomMatchMaker : Photon.PunBehaviour {

	// Use this for initialization
	void Start ()
	{
	    PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Cant join random room!");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        GameObject monster = PhotonNetwork.Instantiate("monsterprefab", Vector3.zero, Quaternion.identity, 0);
        CharacterControl controller = monster.GetComponent<CharacterControl>();
        controller.enabled = true;
        CharacterCamera camera = monster.GetComponent<CharacterCamera>();
        camera.enabled = true;
    }
}
