using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterNsecondsRigidbodyAndCollider : MonoBehaviour {

	public  float lifeTime = 6f;
	private float timePassed;

	private Rigidbody r;
	private Collider c;

	void Start () {
		r = GetComponent<Rigidbody> ();	
		c = GetComponent<Collider> ();
	}

	void Awake () {
		timePassed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;

		if (timePassed > lifeTime) {
			r.isKinematic = true;
			r.detectCollisions = false;
			c.enabled = false;
		}
		
	}
}
