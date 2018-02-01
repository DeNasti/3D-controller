using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {

	public Transform cameraRig;
	public Animator animator;
	private PlayerStats stats;

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
	
		//started sprinting
		if(Input.GetButtonDown("Fire3"))		//fire3 is LShift on pc
			sprinting = true;

			else if(Input.GetButtonUp("Fire3"))
				sprinting = false;

		MovePlayer ();

		if (hz != 0 || vrt != 0) 
			MoveModel ();

		 else
			animator.SetFloat ("SpeedPercent", 0, .1f, Time.deltaTime);
	}	

	void MovePlayer(){
		
		int runMultiplaier=1; //is set to 1 so if the player is not running, the 

		if (sprinting && stats.currentStamina >= 0) {
			runMultiplaier = 4;
			stats.currentStamina -= 8 * Time.deltaTime;
		}
		
		movementVector = new Vector3 (hz * moveSpeed, movementVector.y, vrt * moveSpeed * runMultiplaier);
		movementVector = Quaternion.LookRotation (cameraRig.forward) * movementVector;

		if(charController.isGrounded)
			if(Input.GetButtonDown("Jump"))
				movementVector.y = jumpForce;

		movementVector.y += (Physics.gravity.y * gravityScale);

		charController.Move(movementVector*Time.deltaTime);
	}

	void MoveModel(){
		//the animations are handled throught a blend three: higher is the speed (set with set float) closer the player would be to a running animation.

		if (sprinting && stats.currentStamina >= 0)	//if the player is sprinting, set the proper animation
			animator.SetFloat ("SpeedPercent", 1f, .1f, Time.deltaTime);

		else animator.SetFloat ("SpeedPercent", .5f, .1f, Time.deltaTime);	//else use the working animation

		//Vector3 actualRotation = Mathf.LerpAngle(playerBody.rotation.eulerAngles,cameraRig.forward, .4 );
		playerBody.rotation = Quaternion.RotateTowards(playerBody.rotation, cameraRig.rotation, 300f*Time.deltaTime);
	
	}
		
}
