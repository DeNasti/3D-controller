using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

	public Transform cameraRig;
	public PlayerStats stats;

	public float jumpForce = 3f;
	public float moveSpeed = 4f;
	public float gravityScale = 1f;
	public bool sprinting;

	private CharacterController charController;
	private Vector3 movementVector;
	private Transform playerBody;
	float hz;
	float vrt;


	void Start (){
		charController = GetComponent<CharacterController> ();
		playerBody = transform.GetChild (0).GetComponent<Transform> ();
		stats = GetComponent<PlayerStats> ();

	}

	void Update () {
		 hz = Input.GetAxisRaw ("Horizontal");
		 vrt = Input.GetAxisRaw ("Vertical");
	

		MovePlayer ();

		if (hz != 0 || vrt != 0)
			MoveModel ();
		else {
			stats.animator.SetFloat ("Forward", 0, .1f, Time.deltaTime);
			stats.animator.SetFloat ("Lateral", 0, .1f, Time.deltaTime);
		}

	}	

	void MovePlayer(){

		//started sprinting
		if(Input.GetButtonDown("Fire3"))		//fire3 is LShift on pc
			sprinting = true;

		else if(Input.GetButtonUp("Fire3"))
			sprinting = false;

		// RUNNING
		int runMultiplaier=1; //is set to 1 so if the player is not running, the 

		if (sprinting && stats.currentStamina >= 0) {
			runMultiplaier = 4;
			stats.currentStamina -= 8 * Time.deltaTime;
			hz = 0;

			if (vrt <= 0)
				vrt = 0;
		}

		//WALKING OR RUNNING
		movementVector = new Vector3 (hz * moveSpeed, movementVector.y, vrt * moveSpeed * runMultiplaier);
		movementVector = Quaternion.LookRotation (cameraRig.forward) * movementVector;

		//JUMPING
		if(charController.isGrounded)
			if(Input.GetButtonDown("Jump"))
				movementVector.y = jumpForce;

		movementVector.y += (Physics.gravity.y * gravityScale);
	
		
		charController.Move(movementVector*Time.deltaTime);
	}

	void MoveModel ()
	{
		//the animations are handled throught a blend three: higher is the speed (set with set float) closer the player would be to a running animation.

		if (sprinting && stats.currentStamina >= 0)	//if the player is sprinting, set the proper animation
			stats.animator.SetFloat ("Forward", 2f, .1f, Time.deltaTime);
		

		else {
			stats.animator.SetFloat ("Forward", vrt, .1f, Time.deltaTime);
			stats.animator.SetFloat ("Lateral", hz, .1f, Time.deltaTime);
			}

		//Vector3 actualRotation = Mathf.LerpAngle(playerBody.rotation.eulerAngles,cameraRig.forward, .4 );
		playerBody.rotation = Quaternion.RotateTowards (playerBody.rotation, cameraRig.rotation, 300f * Time.deltaTime);


	}
}