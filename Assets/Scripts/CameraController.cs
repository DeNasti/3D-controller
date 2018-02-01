using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float horizontalSensibility = 5f;
	public float verticalSensibility = 3f;
	public  Transform cameraRig;
	
	private Camera camera;
	private float horizontalRotationAngle;
	private float verticalRotationAngle;
	// Use this for initialization

	void Start () {
		camera = GetComponent<Camera> ();
		//cameraRig = transform.GetComponentInParent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		horizontalRotationAngle = Input.GetAxis ("Mouse X") * horizontalSensibility;
		//transform.RotateAround (cameraRig.transform.position, cameraRig.transform.up, horizontalRotationAngle);
		cameraRig.RotateAround(cameraRig.transform.position, cameraRig.transform.up, horizontalRotationAngle);

		verticalRotationAngle = Input.GetAxis ("Mouse Y") * verticalSensibility;	
		transform.RotateAround (cameraRig.transform.position, cameraRig.transform.right, -verticalRotationAngle);//the minus is inverting the rotation


		
	}

}
