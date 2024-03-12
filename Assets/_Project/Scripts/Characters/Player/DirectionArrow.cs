using HnS.GameStateSystem;
using UnityEngine;

namespace HnS.Characters.Player
{
	public class DirectionArrow : MonoBehaviour
	{
		[SerializeField] private GameObject _arrowRoot;
		
		private LevelFinish _levelFinish;

		private void Awake()
		{
			GameStateManager.StateChanged += OnGameStateChanged;
		}

		private void Start()
		{
			_levelFinish = LevelFinish.Instance;
		}

		private void OnDestroy()
		{
			GameStateManager.StateChanged -= OnGameStateChanged;
		}

		private void OnGameStateChanged(GameState gameState)
		{
			_arrowRoot.SetActive(gameState == GameState.Gameplay);
		}

		private void Update()
		{
			Vector3 direction = _levelFinish.transform.position - transform.position;
			_arrowRoot.transform.rotation = Quaternion.LookRotation(direction);
		}
	}
}