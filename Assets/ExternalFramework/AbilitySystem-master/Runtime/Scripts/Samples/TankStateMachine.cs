using System.Collections;
using System.Collections.Generic;
using CustomizeStateMachine;
using UnityEngine;

namespace CustomizeStateMachine.Samples {
	public class TankStateMachine : BaseMotor {
		public MovementData movementData;
		public Vector3 MoveVector{set; get;}
		public Quaternion RotationQuaternion{set;get;}

		public Transform mTransform;
		public void Start () 
		{
			state = GetComponent<TankIdle> ();
			state.Construct ();
		}
		private void FixedUpdate()
		{
			Debug.Log(currentState);
			state.Transition();
			Move();
		}
		private void Update() 
		{
			Vector3 input=PoolInput();
			MoveVector=state.ProcessMotion(input);
			RotationQuaternion = state.ProcessRotation(input);
			Rotate();
		}
		public void Move()
		{
			rigidbody.linearVelocity = MoveVector*Time.fixedDeltaTime;
		}
		public void Rotate()
		{
			transform.rotation=RotationQuaternion;
		}
		public Vector3 PoolInput()
		{
			Vector3 dir=Vector3.zero;
			dir.x = Input.GetAxisRaw("Horizontal");
			dir.z = Input.GetAxisRaw("Vertical");
			if (dir.sqrMagnitude > 1)
				dir.Normalize ();
			movementData.moveAmount=Mathf.Clamp01(Mathf.Abs(dir.x)+Mathf.Abs(dir.z));
			return dir;
		}
	}
}