using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	public Transform cameraRig;
    public Animator animator;


    public float jumpForce = 3f;
	public float moveSpeed = 4f;
	public bool sprinting;
    public float rotationSpeed = 10f;
    public float raycastDistanceForGround = 2;

    private Rigidbody rb;
	private Vector3 movementVector;
	private Transform playerBody;
	float hz;
	float vrt;
    private bool _jump;
    private bool _isGrounded;
    private bool _isMovingHorizontally;
    Vector3 rot;
    float angle;

    void Start ()
    {
		rb = GetComponent<Rigidbody> ();
        //	playerBody = transform.GetChild (0).GetComponent<Transform> ();
        playerBody = transform;
        _jump = false;
    }

	void Update ()
    {
		hz = Input.GetAxisRaw ("Horizontal");
		vrt = Input.GetAxisRaw ("Vertical");

        if (Input.GetButtonDown("Jump"))
            _jump = true;
    }

    void FixedUpdate ()
    {

        IsGrounded();

        //first i rotate 
        RotatePlayer();
        //then i move in the direction the player is facing
		MovePlayer ();

        //i try to jump
        Jump();

        if (hz != 0 || vrt != 0)
        {
            AnimatePlayer();
        }
        else
        {
            animator.SetFloat("Forward", 0, .1f, Time.fixedDeltaTime);
        }
	}



    private void RotatePlayer()
    {
        //i get the pad angle
        angle = Mathf.Rad2Deg * Mathf.Atan2(hz, vrt);

        //i add it to the camera angle
        angle += cameraRig.transform.eulerAngles.y;

        //i get correct angle with the rest of the division for 360
        angle %= 360;

        //i lerp it
        angle = Mathf.LerpAngle(angle, playerBody.eulerAngles.y, Time.fixedDeltaTime / rotationSpeed);

        //i rotate the character only if there is any axis input 
        if (hz != 0 || vrt != 0)
        {
            _isMovingHorizontally = true;
            playerBody.eulerAngles = new Vector3(playerBody.eulerAngles.x, angle, playerBody.eulerAngles.z);
        }
        else _isMovingHorizontally = false;

    }

    void MovePlayer ()
    {
        if (hz != 0 || vrt != 0)
        {
            var moveVector = (playerBody.transform.forward * moveSpeed * Time.fixedDeltaTime);
//            rb.AddForce(moveVector, ForceMode.Impulse);
            rb.MovePosition(transform.position + moveVector);
        }
    }

    void Jump() {

        //JUMPING
        if (_jump)
        {
            if (_isGrounded) // have to check if rigidbody is grounded
            {
                 rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            _jump = false;
        }
    }
    private void IsGrounded()
    {
        var center = playerBody.position + Vector3.up;

        _isGrounded = (Physics.Raycast(center, Vector3.down, raycastDistanceForGround));
    }

	void AnimatePlayer ()
    {
        //the animations are handled throught a blend three: higher is the speed (set with set float) closer the player would be to a running animation.
        if (_isMovingHorizontally && _isGrounded)
        {
            animator.SetFloat("Forward", 1, .1f, Time.deltaTime);
        }

        else animator.SetFloat("Forward", 0, .1f, Time.deltaTime);
    }

}