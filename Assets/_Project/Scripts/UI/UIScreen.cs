using HnS.GameStateSystem;
using UnityEngine;

namespace HnS
{
    public class UIScreen : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        
        public GameState GameState => _gameState;
    }
}
