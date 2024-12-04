namespace Games.Platformer2D
{
	using UnityEngine;
	using System;
	using System.Collections;

	public class GameManager:MonoBehaviour
	{

		#region PRIVATE_VARS

		[SerializeField] private PlatformGenerator platformGenerator;
		[SerializeField] private Player player;

		#endregion

		#region PUBLIC_VARS

		#endregion

		#region UNITY_CALLBACKS

		private IEnumerator Start()
		{
			yield return new WaitForEndOfFrame();
			player.transform.position = platformGenerator.StartPosition;
		}

		#endregion

		#region PUBLIC_METHODS

		#endregion

		#region PRIVATE_METHODS

		#endregion

	}
}