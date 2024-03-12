using UnityEngine;

namespace HnS
{
	public class GameStarter : MonoBehaviour
	{
		private void Start()
		{
			GameStateManager.CurrentState = GameState.PreGame;
		}
	}
}