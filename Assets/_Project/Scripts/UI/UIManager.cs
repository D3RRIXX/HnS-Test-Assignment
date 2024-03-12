using System.Collections.Generic;
using System.Linq;
using HnS.GameStateSystem;
using UnityEngine;

namespace HnS
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private UIScreen[] _uiScreens;
        
        private Dictionary<GameState, GameObject> _uiScreenMap;

        private void Reset()
        {
            _uiScreens = GetComponentsInChildren<UIScreen>(true);
        }

        private void Awake()
        {
            _uiScreenMap = _uiScreens.ToDictionary(x => x.GameState, x => x.gameObject);

            GameStateManager.StateChanged += OnGameStateChanged;
        }

        private void Start()
        {
            OnGameStateChanged(GameState.Menu);
        }

        private void OnDestroy()
        {
            GameStateManager.StateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            foreach ((GameState state, GameObject screen) in _uiScreenMap)
            {
                screen.SetActive(state == gameState);
            }
        }
    }
}
