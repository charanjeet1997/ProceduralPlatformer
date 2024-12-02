namespace CustomizeStateMachine.Samples {
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine;
	using CustomizeStateMachine;
	[CreateAssetMenu(menuName="TankData")]
	public class TankData : ScriptableObject
	{
		public MovementData movementData;
	}

	[System.Serializable]
	public class MovementData
	{
		public float moveAmount;
		public float moveSpeed;
		public float turnSpeed;
	}
}