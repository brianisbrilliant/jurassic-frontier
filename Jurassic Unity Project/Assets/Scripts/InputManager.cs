using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class InputManager : MonoBehaviour {

	public int playerID = 0, playerSpeed = 50;

	Player player;
	public Rigidbody rb;
	bool fire;

	// Use this for initialization
	void Start () {
		player = ReInput.players.GetPlayer(playerID);
		//rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		GetInput();
		ProcessInput();
	}

	void GetInput() {
		
		//fire = player.GetButtonDown("Fire");
	}

	void ProcessInput() {
		rb.AddForce(player.GetAxis("MoveHorizontal") * playerSpeed, 0, player.GetAxis("MoveVertical") * playerSpeed);
	}
}
