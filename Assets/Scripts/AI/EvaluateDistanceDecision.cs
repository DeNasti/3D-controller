using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/EvaluateDistance")]

public class EvaluateDistanceDecision : Decision {

	public LayerMask viewMask; //to set in the inspector

	private float meleeRangeDistance = 4f; // for now hardcoded


	public override bool Decide(StateController controller){
		return  EvaluateDistance (controller);
	}

	private bool  EvaluateDistance(StateController controller){//is the player near? how much for a transition to melee combat?

		if (Vector3.Distance (controller.transform.position, controller.player.position) <= meleeRangeDistance)
			return true;
	
		else
			return false;	
	}

}
