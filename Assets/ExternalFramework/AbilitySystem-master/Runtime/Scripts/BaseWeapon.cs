namespace CustomizeStateMachine {
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine;
	public class BaseWeapon : MonoBehaviour {
		protected float bulletCount = 30;
		protected float maxBullet = 30;

		public float GetBulletCount { get { return bulletCount; } }
		public float GetMaxBullet { get { return maxBullet; } }
		public virtual void Fire () {
			// if (bulletCount == 0) {
			// 	Reload ();
			// 	return;
			// }
			// bulletCount--;
			// RaycastHit hit;
			// Ray ray = Camera.main.ScreenPointToRay (new Vector2 (Screen.width >> 1, Screen.height >> 1));
			// Physics.Raycast (ray, out hit, 100);
			// DecalManager.Instance.SpawnDecal (hit);

			// // Auto reload on empty
			// if (bulletCount < 1) {
			// 	Reload ();
			// }
		}
		public virtual void Reload () {
			// bulletCount = maxBullet;
		}
	}
}