using HnS.Player;
using UnityEngine;

namespace HnS.AI
{
	public class EnemyAnimator : CharacterAnimatorBase
	{
		[SerializeField] private Animator _animator;

		protected override void SetAnimatorVelocity(float velocity)
		{
			_animator.SetFloat(VELOCITY, velocity);
		}
	}
}