using UnityEngine;

namespace HnS.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerMovement _movement;

        private void Update()
        {
            _movement.MoveInDirection(_joystick.Direction);
        }
    }
}
