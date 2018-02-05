using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public bool betterCamera = false;

	public float currentDistance;

	public float horizontalSensibility = 5f;
	public float verticalSensibility = 3f;
	public  Transform cameraRig;
	public  Transform player;

	public float minCameraDistance = 0f;
	public float maxCameraDistance = 10f;
	
	private Camera thisCamera;
	private float horizontalRotationAngle;
	private float verticalRotationAngle;

	void Start () {
		thisCamera = GetComponent<Camera> ();
	}
	
	//usually late update is used for all the camera movements
	void LateUpdate () {
		horizontalRotationAngle = Input.GetAxis ("Mouse X") * horizontalSensibility;
		//transform.RotateAround (cameraRig.transform.position, cameraRig.transform.up, horizontalRotationAngle);
		cameraRig.RotateAround(cameraRig.transform.position, cameraRig.transform.up, horizontalRotationAngle);

		verticalRotationAngle = Input.GetAxis ("Mouse Y") * verticalSensibility;	
		transform.RotateAround (cameraRig.transform.position, cameraRig.transform.right, -verticalRotationAngle);//the minus is inverting the rotation

		//to avoid the camera is inside something, i have to take the 4 angles of the nearClipPlane, shoot a raycast to the center of the camera
		//and if it intersect an obstacle, just take the camera closer.
		if(betterCamera)
			handleDistance();
	}

	void handleDistance(){

		//first of all i find the 4 point around the camera and the center, then for each of them i shoot a raycast towards the center.
		//i use an array of 4 point, then i pass it to a function that returns the first time the raycast finds the obstacle.
		//so in the best case scenario i have to do only 1 controll, and ONLY in the worse 5.


		bool moved = false;

		if (Vector3.Distance (cameraRig.position, transform.position) > minCameraDistance) {//but only if i'm not yet too close
			
			float x = thisCamera.nearClipPlane;
			float y = Mathf.Tan (thisCamera.fieldOfView / 2) * x;
			float z = y / thisCamera.aspect;

			Vector3[] points = new Vector3[5];

			Quaternion rotation = thisCamera.transform.rotation;

			//top right
			points [0] = (rotation * new Vector3 (x, y, z)) + thisCamera.transform.position;
			//bottom right
			points [1] = (rotation * new Vector3 (x, -y, z)) + thisCamera.transform.position;
			//bottom left
			points [2] = (rotation * new Vector3 (-x, -y, z)) + thisCamera.transform.position;
			//top left
			points [3] = (rotation * new Vector3 (-x, y, z)) + thisCamera.transform.position;
			//center
			points [4] = thisCamera.transform.position;



			for (int i = 0; i < 5; i++) {
				float distanceFromObstacle = 1;
				if (checkIfThereIsObstacle (points [i], player.position, out distanceFromObstacle)) { //if there is an obstacle between the point of the camera and the player
					translateCamera (thisCamera.transform.forward * distanceFromObstacle, 100f);
					moved = true;
					break;
				}
			}
		}

		if (!moved) {//if the camera was not moved forward i go back to the starting distance
			if(Vector3.Distance(cameraRig.position, transform.position) < maxCameraDistance)//but only if i'm not yet at the proper distance
				translateCamera(-thisCamera.transform.forward, 1f);
		}
			
		currentDistance = Vector3.Distance (cameraRig.position, transform.position);
	}

	bool checkIfThereIsObstacle(Vector3 startingPoint, Vector3 target, out float distanceFromObstacle){
		RaycastHit hit;
		distanceFromObstacle = 1;

		if (Physics.Raycast (startingPoint, target, out hit, maxCameraDistance * 2)) {//i shoot my raycast
			if (hit.collider.gameObject.tag != "Player") { // if i hit something that is not the player
				//if(hit.distance > 1)
					distanceFromObstacle = hit.distance;//collider.gameObject.gameObject.transform.position, thisCamera.transform.position);
				
				Debug.Log ("the raycast hit an object that is not our player");
				return true; //I return true
			}
		}
			return false;
	}

	void translateCamera(Vector3 destination, float tranlationSpeed){
		thisCamera.transform.position = Vector3.Lerp(thisCamera.transform.position, thisCamera.transform.position + destination , Time.deltaTime*tranlationSpeed);
	}



}
