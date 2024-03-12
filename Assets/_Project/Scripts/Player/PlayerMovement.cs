using UnityEngine;

namespace HnS.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _moveSpeed = 3f;

		private Rigidbody _rb;

		public Vector3 Velocity { get; private set; }
		
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
			var dir = new Vector3(direction.x, 0f, direction.y);
			Velocity = dir * _moveSpeed;
		}

		private void MoveInDirection()
		{
			_rb.MovePosition(_rb.position + Velocity * Time.deltaTime);
			// transform.position += Velocity * Time.deltaTime;

			RotateTowardsMovement(Velocity.normalized);
		}

		private void RotateTowardsMovement(Vector3 dir)
		{
			if (dir.sqrMagnitude == 0f)
				return;
			
			transform.rotation = Quaternion.LookRotation(dir);
		}
	}
}