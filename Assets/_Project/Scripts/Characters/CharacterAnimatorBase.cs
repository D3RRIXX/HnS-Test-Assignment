using UnityEngine;

namespace HnS.Characters
{
	public abstract class CharacterAnimatorBase : MonoBehaviour
	{
		[SerializeField] private float _smoothTime;
		
		private ICharacterMovement _movement;
		private float _cachedVelocity;
		private float _currentVelocity;
		
		protected static readonly int VELOCITY = Animator.StringToHash("Velocity");

		protected virtual void Awake()
		{
			_movement = GetComponentInParent<ICharacterMovement>();
		}

		private void LateUpdate()
		{
			float targetVelocity = Mathf.InverseLerp(0f, _movement.MaxSpeed, _movement.Velocity.magnitude);
			_cachedVelocity = Mathf.SmoothDamp(_cachedVelocity, targetVelocity, ref _currentVelocity, _smoothTime, Mathf.Infinity, Time.deltaTime);

			SetAnimatorVelocity(_cachedVelocity);
		}

		protected abstract void SetAnimatorVelocity(float velocity);
	}
}