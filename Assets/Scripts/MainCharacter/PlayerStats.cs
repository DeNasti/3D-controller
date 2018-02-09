using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public float currentHp = 100f;
	public float currentStamina = 100f;

	public float maxHp = 100f;
	public float maxStamina = 100f;

	public float staminaRegen = 2f; //how many stamina points are regenered per second

	public float damageOutput = 6f;

	public float staminaForAttack = 20f;

	public Slider healtSlider;
	public Slider StaminaSlider;

	public Animator animator;

	void Start(){
		healtSlider.maxValue = maxHp;
		StaminaSlider.maxValue = maxStamina;
	}

	// Update is called once per frame
	void Update () {
		if (currentStamina > maxStamina)
			currentStamina = maxStamina;
		else currentStamina += (staminaRegen * Time.deltaTime);

		healtSlider.value = currentHp;
		StaminaSlider.value = currentStamina;
	}
}
