using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

	public float hp = 3;
	public GameObject destroyedVersion;

		void OnTriggerEnter (Collider col) {
		Debug.Log ("trigger enter: " + col.tag);

		if(col.tag == Tags.sword){
			PlayerStats s = col.gameObject.transform.root.gameObject.GetComponent<PlayerStats>();
			hp -= s.damageOutput;
		}
		
		if (hp <= 0) {
			GameObject.Instantiate (destroyedVersion, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}
}
