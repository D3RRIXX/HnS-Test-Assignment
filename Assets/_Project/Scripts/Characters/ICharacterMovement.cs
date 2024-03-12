using UnityEngine;

namespace HnS.Characters
{
	public interface ICharacterMovement
	{
		Vector3 Velocity { get; }
		float MaxSpeed { get; }
	}
}