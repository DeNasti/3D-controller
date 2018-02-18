using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : AbstractAction{

	public override void Act (StateController controller){
		Attack (controller);
	}

	private void Attack(StateController controller){
		if(!controller.navMeshAgent.isStopped)
			controller.navMeshAgent.isStopped = true;
		/*
		 RaycastHit hit;
		 
		 Debug.DrawRay (controller.eyes.position, controller.eyes.forward.normalized * controller.viewDistance, Color.green);

		if (Physics.SphereCast (controller.eyes.position, 0.2f, controller.eyes.forward, out hit, controller.guardStats.viewDistance * 1.4f) 
			&& hit.collider.CompareTag("Player")) {
			if (controller.CheckIfCountdownElapsed (controller.guardStats.attackRate)) {
				//controller.guardShooting.Fire (controller.eyes);
				Debug.Log ("boom");
				\
			}
		}*/
			
	}
}