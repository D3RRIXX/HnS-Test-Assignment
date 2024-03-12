using UnityEngine;

namespace HnS
{
	public class LevelFinish : MonoBehaviour
	{
		public static LevelFinish Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
		}
	}
}