using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour {

	virtual public void hit(float damage){
		Debug.Log ("implement this method in a inheritant class");
	}
}
