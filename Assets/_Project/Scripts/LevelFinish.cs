using HnS.GameStateSystem;
using UnityEngine;

namespace HnS
{
	public class LevelFinish : MonoBehaviour
	{
		public static LevelFinish Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
				GameStateManager.CurrentState = GameState.LevelComplete;
		}
	}
}