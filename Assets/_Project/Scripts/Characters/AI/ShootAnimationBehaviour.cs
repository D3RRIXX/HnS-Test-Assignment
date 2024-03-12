using HnS.GameStateSystem;
using UnityEngine;

namespace HnS.Characters.AI
{
	public class ShootAnimationBehaviour : StateMachineBehaviour
	{
		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			GameStateManager.CurrentState = GameState.LevelFailed;
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

		public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }

		public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }
	}
}