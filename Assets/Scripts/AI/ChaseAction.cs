using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : AbstractAction {

	public override void Act (StateController controller){
		Chase (controller);
	}

	private void Chase(StateController controller){
		controller.navMeshAgent.destination = controller.player.position;
	if(controller.navMeshAgent.isStopped)
		controller.navMeshAgent.isStopped = false;
	}

}