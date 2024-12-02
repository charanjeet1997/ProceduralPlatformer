namespace CustomizeStateMachine {
	using System.Collections.Generic;
	using System.Collections;
	using UnityEngine;
	//T = Base Hero 
	//U = Base Motor
	//V = Base Weapon
	public class BaseHero : MonoBehaviour {
		protected BaseMotor motor;
		protected BaseWeapon weapon;
		protected IItemPicker itemPicker;
		protected IDamageable _damageable;
	
		public List<BaseAbility> abilities;

		public void RegisterAbiltity (BaseAbility abiltiy) {
			if (!abilities.Contains (abiltiy)) {
				abilities.Add (abiltiy);
			}
		}
		
		public virtual void Update () {
			PoolInput ();
		}

		public virtual void PoolInput () {
			foreach(BaseAbility ability in abilities)
			{
				CastAbility(ability);
			}
		}
		protected virtual void CastAbility (BaseAbility ability) {
			ability.CastAbility();
		}
		public void UnRegisterAbility (BaseAbility ability) {
			if (abilities.Contains (ability)) {
				abilities.Remove (ability);
			}
		}
		public BaseMotor GetMotor () {
			if (!motor)
				motor = GetComponent<BaseMotor> ();
			return motor;
		}
		public BaseWeapon GetWeapon () {
			if (!weapon)
				weapon = GetComponent<BaseWeapon> ();
			return weapon;
		}
	}
}