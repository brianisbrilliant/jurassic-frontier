using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	int playerId = 0; 								// The Rewired player id of this character

    public float moveSpeed = 300.0f;
    public float bulletSpeed = 15.0f;
    //ublic GameObject bulletPrefab;


    private Player player; 					// The Rewired Player
    //private CharacterController cc;
    private Vector3 moveVector;
    private bool attack, use;
	private Rigidbody rb;

	void Awake() {
        // Get the Rewired Player object for this player and keep it for the duration of the character's lifetime
        player = ReInput.players.GetPlayer(playerId);
		rb = this.GetComponent<Rigidbody>();
    }

    void Update () {
        GetInput();
        ProcessInput();
    }

	private void GetInput() {
        // Get the input from the Rewired Player. All controllers that the Player owns will contribute, so it doesn't matter
        // whether the input is coming from a joystick, the keyboard, mouse, or a custom controller.

        moveVector.x = player.GetAxis("MoveHorizontal"); // get input by name or action id
        moveVector.z = player.GetAxis("MoveVertical");
        attack = player.GetButtonDown("Attack");
		use = player.GetButtonDown("Use");
    }

    private void ProcessInput() {
        // Process movement
        if(moveVector.x != 0.0f || moveVector.z != 0.0f) {
			Debug.Log("MoveVector.x and .z = " + moveVector.x + " " + moveVector.z);
			rb.AddForce(moveVector * moveSpeed, ForceMode.Impulse);
        }

        // Process fire
        if(attack) {
            //GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + transform.right, transform.rotation);
            //bullet.rigidbody.AddForce(transform.right * bulletSpeed, ForceMode.VelocityChange);
        }
		if(use) {

		}
    }
}
