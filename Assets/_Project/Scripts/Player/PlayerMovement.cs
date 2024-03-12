using UnityEngine;

namespace HnS
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _moveSpeed = 3f;

		public float MaxSpeed => _moveSpeed;
		public Vector3 Velocity { get; private set; }

		public void MoveInDirection(Vector2 direction)
		{
			Velocity = new Vector3(direction.x, 0f, direction.y) * _moveSpeed;
			transform.position += Velocity * Time.deltaTime;
		}
	}
}