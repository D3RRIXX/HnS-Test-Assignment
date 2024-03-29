using UnityEngine;

namespace HnS.Characters.Player
{
	public class PlayerMovement : MonoBehaviour, ICharacterMovement
	{
		[SerializeField] private float _moveSpeed = 3f;

		private Rigidbody _rb;
		private Vector3 _inputDirection;

		public Vector3 Velocity { get; private set; }

		public bool IsHiding => Velocity == Vector3.zero;
		public float MaxSpeed => _moveSpeed;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			MoveInDirection();
		}

		public void ConsumeMovementInput(Vector2 direction)
		{
			_inputDirection = new Vector3(direction.x, 0f, direction.y);
		}

		private void MoveInDirection()
		{
			Velocity = _inputDirection * _moveSpeed;
			_rb.MovePosition(_rb.position + Velocity * Time.deltaTime);

			RotateTowardsMovement(_inputDirection);
			_inputDirection = Vector3.zero;
		}

		private void RotateTowardsMovement(Vector3 dir)
		{
			if (dir.sqrMagnitude == 0f)
				return;
			
			transform.rotation = Quaternion.LookRotation(dir);
		}
	}
}