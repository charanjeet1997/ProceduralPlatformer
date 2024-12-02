namespace CustomizeStateMachine {
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine;
	[System.Serializable]
	public class GroundSensor : BaseSensor {

		public BaseMotor baseMotor;
		public Vector3 SlopeNormal;
		// CONST
		private const float DISTANCE_GROUNDED = 0.5f;
		private const float INNER_OFFSET_GROUNDED = 0.05f;
		private const float SLOPE_TRESHOLD = 0.55f;

		public override bool Sense () {
			float yRay = baseMotor.capsuleCollider.bounds.center.y - (baseMotor.capsuleCollider.height * 0.5f) + 0.3f;
			RaycastHit hit;

			// Mid
			if (Physics.Raycast (new Vector3 (baseMotor.capsuleCollider.bounds.center.x, yRay, baseMotor.capsuleCollider.bounds.center.z), -Vector3.up, out hit, DISTANCE_GROUNDED)) {
				SlopeNormal = hit.normal;
				return (SlopeNormal.y > SLOPE_TRESHOLD) ? true : false;
			}

			// Front-Right
			if (Physics.Raycast (new Vector3 (baseMotor.capsuleCollider.bounds.center.x + (baseMotor.capsuleCollider.bounds.extents.x - INNER_OFFSET_GROUNDED), yRay, baseMotor.capsuleCollider.bounds.center.z + (baseMotor.capsuleCollider.bounds.extents.z - INNER_OFFSET_GROUNDED)), -Vector3.up, out hit, DISTANCE_GROUNDED)) {
				SlopeNormal = hit.normal;
				return (SlopeNormal.y > SLOPE_TRESHOLD) ? true : false;
			}

			// Front-Left
			if (Physics.Raycast (new Vector3 (baseMotor.capsuleCollider.bounds.center.x - (baseMotor.capsuleCollider.bounds.extents.x - INNER_OFFSET_GROUNDED), yRay, baseMotor.capsuleCollider.bounds.center.z + (baseMotor.capsuleCollider.bounds.extents.z - INNER_OFFSET_GROUNDED)), -Vector3.up, out hit, DISTANCE_GROUNDED)) {
				SlopeNormal = hit.normal;
				return (SlopeNormal.y > SLOPE_TRESHOLD) ? true : false;
			}
			// Back Right
			if (Physics.Raycast (new Vector3 (baseMotor.capsuleCollider.bounds.center.x + (baseMotor.capsuleCollider.bounds.extents.x - INNER_OFFSET_GROUNDED), yRay, baseMotor.capsuleCollider.bounds.center.z - (baseMotor.capsuleCollider.bounds.extents.z - INNER_OFFSET_GROUNDED)), -Vector3.up, out hit, DISTANCE_GROUNDED)) {
				SlopeNormal = hit.normal;
				return (SlopeNormal.y > SLOPE_TRESHOLD) ? true : false;
			}
			// Back Left
			if (Physics.Raycast (new Vector3 (baseMotor.capsuleCollider.bounds.center.x - (baseMotor.capsuleCollider.bounds.extents.x - INNER_OFFSET_GROUNDED), yRay, baseMotor.capsuleCollider.bounds.center.z - (baseMotor.capsuleCollider.bounds.extents.z - INNER_OFFSET_GROUNDED)), -Vector3.up, out hit, DISTANCE_GROUNDED)) {
				SlopeNormal = hit.normal;
				return (SlopeNormal.y > SLOPE_TRESHOLD) ? true : false;
			}

			return false;
		}
	}
}