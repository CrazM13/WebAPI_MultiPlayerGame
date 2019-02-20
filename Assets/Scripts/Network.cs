using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Network : MonoBehaviour {

	SocketIOComponent socket;

	public GameObject playerPrefab;

	void Start () {
		socket = GetComponent<SocketIOComponent>();

		socket.On("open", OnConnected);
		socket.On("talkback", OnTalkBack);
		socket.On("spawn", OnSpawn);
	}

	private void OnSpawn(SocketIOEvent obj) {
		Debug.Log("Player Spawn");
		Instantiate(playerPrefab);
	}

	private void OnTalkBack(SocketIOEvent obj) {
		Debug.Log("The Server Says \"Hello\" Back");
	}

	private void OnConnected(SocketIOEvent obj) {
		Debug.Log("Connected To Server");

		socket.Emit("sayhello");
	}

}
