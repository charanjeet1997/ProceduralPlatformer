namespace CustomizeStateMachine {
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine;
	public class BaseMotor : MonoBehaviour {
		public CapsuleCollider capsuleCollider;
		public Rigidbody rigidbody;

		public BaseState[] availableStates;
		[HideInInspector]
		public BaseState state;
		[HideInInspector]
		public string currentState;
		public virtual void ChangeState (BaseState s) {
			state.Destruct ();
			state = s;
			state.Construct ();
			currentState=s.GetType().Name;
		}
		public virtual void ChangeState (string stateName) {
			foreach (var s in availableStates) {
				Debug.Log(s.GetType ().Name);
				if (s.GetType ().Name != stateName)
					continue;
				if (s.unlocked) {
					state.Destruct ();
					state = s;
					state.Construct ();
				}
				currentState=stateName;
				return;
			}
		}
	}
}