namespace CustomizeStateMachine.Samples {
	using System.Collections.Generic;
	using System.Collections;
	using CustomizeStateMachine;
	using UnityEngine;

	public class SendHitAbility : BaseAbility 
	{
        [SerializeField] private BaseHero baseHero;

		public LayerMask mask;
		public float hitForce = 5f;
		private bool isHit;
		private Rigidbody objectToHit;

        public override void CastAbility () {
			if (isHit) {
				isHit = false;
				objectToHit.AddForce (baseHero.GetMotor ().rigidbody.linearVelocity * hitForce, ForceMode.Impulse);
				Debug.Log ("Hit Sent : ");
			}
		}
		private void OnCollisionEnter (Collision other) {
			if (((1 << other.gameObject.layer) & mask) == 0)
				return;
			objectToHit = other.rigidbody;
			isHit = true;
		}
		private void OnCollisionStay (Collision other) {
			if (((1 << other.gameObject.layer) & mask) == 0)
				return;
			objectToHit = other.rigidbody;
			isHit = true;
		}
	}
}