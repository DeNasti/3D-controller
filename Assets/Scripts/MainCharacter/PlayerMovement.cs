using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	public Transform cameraRig;
	public PlayerStats stats;

	public float jumpForce = 3f;
	public float moveSpeed = 4f;
	public float gravityScale = 1f;
	public bool sprinting;
    public float rotationSpeed = 10f;

    private Rigidbody rb;
	private Vector3 movementVector;
	private Transform playerBody;
	float hz;
	float vrt;
    Vector3 rot;

    void Start ()
    {
		rb = GetComponent<Rigidbody> ();
		playerBody = transform.GetChild (0).GetComponent<Transform> ();
		stats = GetComponent<PlayerStats> ();

	}

	void Update ()
    {
		hz = Input.GetAxis ("Horizontal");
		vrt = Input.GetAxis ("Vertical");
    }

	void FixedUpdate ()
    {

		MovePlayer ();
        RotatePlayer();
        if (hz != 0 || vrt != 0)
        {
            AnimatePlayer();
        }
        else
        {
            stats.animator.SetFloat("Forward", 0, .1f, Time.fixedDeltaTime);
        }
	}


    void MovePlayer ()
    {
        movementVector = new Vector3 (hz , 0, vrt ) * moveSpeed;
		movementVector = Quaternion.LookRotation(cameraRig.forward, Vector3.up) * movementVector;

        //JUMPING
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded()) // have to check if rigidbody is grounded
            {
                movementVector.y = jumpForce;
            }
        }
        rb.AddForce(movementVector * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void RotatePlayer()
    {
        //i get the pad angle
        var angle = Mathf.Rad2Deg * Mathf.Atan2(hz, vrt);

        //i add it to the camera angle
        angle += cameraRig.transform.eulerAngles.y;

        //i get correct angle with the rest of the division for 360
        angle = angle % 360;

        //i lerp it
        angle = Mathf.LerpAngle(angle, playerBody.eulerAngles.y, Time.fixedDeltaTime / rotationSpeed);

        //i rotate the character only if there is any axis input 
        if (hz != 0 || vrt != 0)
        {
            playerBody.eulerAngles = new Vector3(playerBody.eulerAngles.x, angle, playerBody.eulerAngles.z);
        }
    }


    private bool isGrounded ()
    {
		return true;
	}

	void AnimatePlayer ()
    {
        //the animations are handled throught a blend three: higher is the speed (set with set float) closer the player would be to a running animation.

        if (sprinting && stats.currentStamina >= 0) //if the player is sprinting, set the proper animation
        {
            stats.animator.SetFloat("Forward", 1.5f, .1f, Time.deltaTime);
        }

        else
        {
            stats.animator.SetFloat("Forward", 1, .1f, Time.deltaTime);
        }

	}
}