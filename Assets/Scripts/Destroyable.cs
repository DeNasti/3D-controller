using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : Hittable {

	public float hp = 3;
	public GameObject destroyedVersion;

	public override void hit(float damage){

		hp -= damage;

		if (hp <= 0) {
			GameObject.Instantiate (destroyedVersion, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
	}



}
