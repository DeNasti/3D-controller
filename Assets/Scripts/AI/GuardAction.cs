using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Guard")]

public class GuardAction : AbstractAction {

	public override void Act (StateController controller){
		Guard (controller);
	}

	private void Guard(StateController controller){
		controller.navMeshAgent.isStopped = true;
	}
}
