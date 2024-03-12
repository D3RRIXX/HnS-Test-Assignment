using HnS.GameStateSystem;
using UnityEngine;

namespace HnS.Characters.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerMovement _movement;

        private bool _movementEnabled;

        private void Awake()
        {
            GameStateManager.StateChanged += OnGameStateChanged;
        }
        
		private void OnDestroy()
		{
			GameStateManager.StateChanged -= OnGameStateChanged;
		}

        private void OnGameStateChanged(GameState state)
        {
            _movementEnabled = state == GameState.Gameplay;
        }

        private void Update()
        {
			if (!_movementEnabled)
				return;
            
            _movement.ConsumeMovementInput(_joystick.Direction);
        }
    }
}
