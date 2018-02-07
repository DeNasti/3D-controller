using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour {

	public PlayerStats stats;

	void Start(){
		//stats = transform.root.GetComponent<PlayerStats>();
	}

	void OnCollisionEnter (Collision col) {
		Debug.Log ("collider enter: " + col.collider.tag);

		Hittable h = col.gameObject.GetComponent<Hittable> ();

		if (h != null)
			h.hit (stats.damageOutput);
	}	

	void OnTriggerEnter (Collider col) {
		Debug.Log (" enter: " + col.tag);

		Hittable h = col.gameObject.GetComponent<Hittable> ();

		if (h != null)
			h.hit (stats.damageOutput);
	}

}
