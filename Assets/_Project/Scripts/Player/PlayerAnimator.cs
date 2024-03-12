using System;
using UnityEngine;

namespace HnS.Player
{
	public class PlayerAnimator : MonoBehaviour
	{
		[SerializeField] private Animator _character;
		[SerializeField] private Animator _barrel;
		[SerializeField] private float _smoothTime;

		private PlayerMovement _movement;
		private float _cachedVelocity;
		private float _currentVelocity;

		private static readonly int VELOCITY = Animator.StringToHash("Velocity");
		private static readonly int GAME_START = Animator.StringToHash("GameStart");

		private void Awake()
		{
			_movement = GetComponentInParent<PlayerMovement>();
		}

		private void Start()
		{
			GameStateManager.StateChanged += OnStateChanged;
		}

		private void OnDestroy()
		{
			GameStateManager.StateChanged -= OnStateChanged;
		}

		private void OnStateChanged(GameState gameState)
		{
			switch (gameState)
			{
				case GameState.Gameplay:
					ApplyToAllAnimators(x => x.SetTrigger(GAME_START));
					break;
			}
		}

		private void LateUpdate()
		{
			float targetVelocity = Mathf.InverseLerp(0f, _movement.MaxSpeed, _movement.Velocity.magnitude);
			_cachedVelocity = Mathf.SmoothDamp(_cachedVelocity, targetVelocity, ref _currentVelocity, _smoothTime, Mathf.Infinity, Time.deltaTime);

			SetAnimatorVelocity(_cachedVelocity);
		}

		private void SetAnimatorVelocity(float velocity)
		{
			ApplyToAllAnimators(x => x.SetFloat(VELOCITY, velocity));
		}

		private void ApplyToAllAnimators(Action<Animator> action)
		{
			action(_character);
			action(_barrel);
		}
	}
}