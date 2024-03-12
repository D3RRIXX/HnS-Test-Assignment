using UnityEngine;

namespace HnS
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _character;
        [SerializeField] private Animator _barrel;
        [SerializeField] private float _smoothTime;

        private PlayerMovement _movement;
        private float _cachedVelocity;
        private float _currentVelocity;
        
        private static readonly int VELOCITY = Animator.StringToHash("Velocity");

        private void Awake()
        {
            _movement = GetComponentInParent<PlayerMovement>();
        }

        private void LateUpdate()
        {
            float targetVelocity = Mathf.InverseLerp(0f, _movement.MaxSpeed, _movement.Velocity.magnitude);
            _cachedVelocity = Mathf.SmoothDamp(_cachedVelocity, targetVelocity, ref _currentVelocity, _smoothTime, Mathf.Infinity, Time.deltaTime);
            
            SetAnimatorVelocity(_cachedVelocity);
        }

        private void SetAnimatorVelocity(float velocity)
        {
            _character.SetFloat(VELOCITY, velocity);
            _barrel.SetFloat(VELOCITY, velocity);
        }
    }
}
