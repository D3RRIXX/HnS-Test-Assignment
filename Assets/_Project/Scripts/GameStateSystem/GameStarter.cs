using UnityEngine;

namespace HnS.GameStateSystem
{
	public class GameStarter : MonoBehaviour
	{
		private void Start()
		{
			GameStateManager.CurrentState = GameState.PreGame;
		}
	}
}