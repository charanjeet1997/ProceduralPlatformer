using System;

namespace CustomizeStateMachine {
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine;
	public class BaseState : MonoBehaviour {
		public bool unlocked = true;
		[HideInInspector]
		public BaseMotor baseMotor;
		protected BaseHero baseHero;
		protected float startTime;
		protected float immuneTime;

		private void Start()
		{
			if (baseMotor == null) baseMotor = GetComponent<BaseMotor>();
		}

		public virtual void Construct () {
			startTime = Time.time;
		}
		public virtual void Destruct () {

		}
		public virtual void Transition () {
			if (Time.time - startTime < immuneTime)
				return;
		}
		public virtual void ProcessAnimation (Animator animator) {

		}

		public virtual Vector3 ProcessMotion(Vector3 input)
		{
			return Vector3.zero;
		}

		public virtual Quaternion ProcessRotation (Vector3 input) {
			return Quaternion.identity;
		}
		public virtual void OnAnimationEnded () {

		}
		protected BaseHero GetBaseHero () {
			if (!baseHero)
				baseHero = GetComponent<BaseHero> ();
			return baseHero;
		}
		protected BaseMotor GetBaseMotor () {
			if (!baseMotor)
				baseMotor = GetComponent<BaseMotor> ();
			return baseMotor;
		}
	}
}