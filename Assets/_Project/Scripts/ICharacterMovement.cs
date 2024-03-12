using UnityEngine;

namespace HnS
{
	public interface ICharacterMovement
	{
		Vector3 Velocity { get; }
		float MaxSpeed { get; }
	}
}