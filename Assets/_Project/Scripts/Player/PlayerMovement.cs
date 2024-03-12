using UnityEngine;

namespace HnS.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _moveSpeed = 3f;

		public Vector3 Velocity { get; private set; }
		public bool MovementEnabled { get; private set; }
		
		public float MaxSpeed => _moveSpeed;

		public void MoveInDirection(Vector2 direction)
		{
			if (!MovementEnabled)
				return;
			
			var dir = new Vector3(direction.x, 0f, direction.y);
			Velocity = dir * _moveSpeed;
			transform.position += Velocity * Time.deltaTime;
			
			RotateTowardsMovement(dir);
		}

		private void RotateTowardsMovement(Vector3 dir)
		{
			if (dir.sqrMagnitude == 0f)
				return;
			
			transform.rotation = Quaternion.LookRotation(dir);
		}
	}
}