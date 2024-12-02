using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomizeStateMachine;
namespace CustomizeStateMachine.Samples {
	public class TankWalk : CustomizeStateMachine.BaseState 
	{
		public TankStateMachine tankStateMachine;
		[HideInInspector]
		public Tank tank;
		public override Vector3 ProcessMotion(Vector3 input)
		{
			Vector3 FinalVelocity = ((tankStateMachine.mTransform.forward*input.z)*tankStateMachine.movementData.moveAmount*tankStateMachine.movementData.moveSpeed);
			return FinalVelocity;
		}
		public override Quaternion ProcessRotation(Vector3 input)
		{
			Vector3 cameraForward = tankStateMachine.mTransform.forward;
			cameraForward += tankStateMachine.mTransform.right*input.x;
			cameraForward.Normalize();
			cameraForward.y=0;
			return Quaternion.Slerp(tankStateMachine.mTransform.rotation,Quaternion.LookRotation(cameraForward),Time.fixedDeltaTime*tankStateMachine.movementData.turnSpeed);  
		}
		public override void Transition()
		{
			if(tankStateMachine.movementData.moveAmount==0)
			{
				baseMotor.ChangeState("TankIdle");
			}
		}
	}
}