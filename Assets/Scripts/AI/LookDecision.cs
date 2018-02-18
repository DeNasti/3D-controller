using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision {

	public LayerMask viewMask; //to set in the inspector

	private float viewAngle = 80f; //angle of the spotlight, for now hardcoded


	public override bool Decide(StateController controller){
		return Look (controller);
	}

	private bool Look(StateController controller){//can the AI see the player?

		if(Vector3.Distance(controller.transform.position, controller.player.position) < controller.viewDistance){
			Vector3 dirToPlayer = (controller.player.position - controller.transform.position).normalized;
			float angleBetweenGuardAndPlayer = Vector3.Angle (controller.eyes.transform.forward, dirToPlayer);

			if (angleBetweenGuardAndPlayer < viewAngle / 2f) {
				if (!Physics.Linecast (controller.eyes.transform.position, controller.player.position, viewMask)) {
					//controller.chaseTarget = player.position (?)

					Debug.Log ("returning true");
					return true;
				}
			}
		}

		return false;	}
}
