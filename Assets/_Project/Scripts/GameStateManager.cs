using System;
using UnityEngine;

namespace HnS
{
	public static class GameStateManager
	{
		private static GameState currentState;

		public static event Action<GameState> StateChanged;
		
		public static GameState CurrentState
		{
			get => currentState;
			set
			{
				if (currentState == value)
					return;

				Debug.Log($"Game State changed to {value}");
				currentState = value;
				StateChanged?.Invoke(value);
			}
		}
	}
}