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
			
		if (Input.GetButtonDown ("Fire2"))		//TO DO set defense state
			stats.animator.SetBool ("Defend", true);
		
		else if (Input.GetButtonUp ("Fire2"))
			stats.animator.SetBool ("Defend", false);
		
		else if (Input.GetButtonDown ("Fire1")) {	//trying to attack
			if (stats.currentStamina > stats.staminaForAttack) {	//check if it has enough stamina
				if (!IsPlayingAttackAnimation ()) {		//if no attack is being played, do the first of the combo
					stats.currentStamina -= stats.staminaForAttack;
					stats.animator.SetTrigger ("Attack");
				}
			/*	else if (stats.animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack")) {		//if the first attack is being played, activate the second one
					Debug.Log("here");
					stats.currentStamina -= stats.staminaForAttack;
					stats.animator.SetTrigger ("Attack_2");
				} */
			}
		}

	}

	bool IsPlayingAttackAnimation(){
	 return (stats.animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack") || stats.animator.GetCurrentAnimatorStateInfo (0).IsName ("Attack2"));
	}
}
