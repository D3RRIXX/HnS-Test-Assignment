using HnS.GameStateSystem;
using UnityEngine;
using UnityEngine.UI;

namespace HnS
{
	[RequireComponent(typeof(Button))]
	public class MainMenuScreen : MonoBehaviour
	{
		private void Awake()
		{
			GetComponent<Button>().onClick.AddListener(() => GameStateManager.CurrentState = GameState.PreGame);
		}
	}
}