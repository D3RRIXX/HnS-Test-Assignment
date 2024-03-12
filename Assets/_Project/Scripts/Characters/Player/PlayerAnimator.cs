using System;
using HnS.GameStateSystem;
using UnityEngine;

namespace HnS.Characters.Player
{
	public class PlayerAnimator : CharacterAnimatorBase
	{
		[SerializeField] private Animator _character;
		[SerializeField] private Animator _barrel;

		private static readonly int GAME_START = Animator.StringToHash("GameStart");

		protected override void Awake()
		{
			base.Awake();
			GameStateManager.StateChanged += OnGameStateChanged;
		}

		private void OnDestroy()
		{
			GameStateManager.StateChanged -= OnGameStateChanged;
		}

		private void OnGameStateChanged(GameState gameState)
		{
			switch (gameState)
			{
				case GameState.PreGame:
					ApplyToAllAnimators(x => x.SetTrigger(GAME_START));
					break;
			}
		}

		protected override void SetAnimatorVelocity(float velocity)
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