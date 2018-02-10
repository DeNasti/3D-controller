using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

	public PlayerStats stats;

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		Combat ();
	}


	void Combat(){
		if (Input.GetButtonDown ("Fire1")  && !IsPlayingAttackAnimation())
			if (stats.currentStamina > stats.staminaForAttack ) {

				stats.currentStamina -= stats.staminaForAttack ;
				stats.animator.SetTrigger ("Attack");
			}		
	}

	bool IsPlayingAttackAnimation(){
		return (stats.animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack") || stats.animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack2"));
	}
}
