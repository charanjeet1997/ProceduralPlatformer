namespace CustomizeStateMachine
{ 
    using UnityEngine;
    using Games.UnnamedArcade3d.Entities;

    /// <summary>
    /// This is the base class of all the abilities that you build.
    /// It also inject it's require dependency at editor time which is base hero so make sure to add one before adding this one.
    /// 

    public abstract class BaseAbility : MonoBehaviour
    {
        [SerializeField] protected float cooldownDuration = 0.5f;
        protected float lastCastTime;

        public float RemainingCooldown
        {
            get
            {
                float remainingCooldown = cooldownDuration - (Time.time - lastCastTime);
                return remainingCooldown <= 0 ? 0 : remainingCooldown;
            }
        }

        public virtual void CastAbility()
        {
            if (IsCoolDownComplete())
                lastCastTime = Time.time;
        }

        protected bool IsCoolDownComplete()
        {
            return Time.time - lastCastTime > cooldownDuration;
        }
    }
}