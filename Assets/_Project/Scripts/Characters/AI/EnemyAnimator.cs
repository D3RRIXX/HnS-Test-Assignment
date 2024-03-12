using UnityEngine;

namespace HnS.Characters.AI
{
	public class EnemyAnimator : CharacterAnimatorBase
	{
		[SerializeField] private Animator _animator;
		
		private static readonly int SPOTTED_PLAYER = Animator.StringToHash("SpottedPlayer");

		protected override void SetAnimatorVelocity(float velocity)
		{
			_animator.SetFloat(VELOCITY, velocity);
		}

		public void PlayShootAnim()
		{
			_animator.SetTrigger(SPOTTED_PLAYER);
		}
	}
}