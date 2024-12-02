namespace CustomizeStateMachine
{
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine;

	[System.Serializable]
	public class BaseSensor 
	{
		public virtual bool Sense()
		{
			return true;
		}
	}
}