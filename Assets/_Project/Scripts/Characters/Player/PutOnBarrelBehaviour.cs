using HnS.GameStateSystem;
using UnityEngine;

namespace HnS.Characters.Player
{
	public class PutOnBarrelBehaviour : StateMachineBehaviour
	{
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			GameStateManager.CurrentState = GameState.Gameplay;
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

		public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

		public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
	}
}