using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour {

	public PlayerStats stats;

	void Start(){
		if(stats == null)
			stats = GetComponent<PlayerStats> ();
	}

	void OnTriggerEnter (Collider col) {
		//Debug.Log (" enter: " + col.tag);

		Hittable h = col.gameObject.GetComponent<Hittable> ();
		if(stats.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || stats.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") ){
			if (h != null)
				h.hit (stats.damageOutput);
		}
	}
}