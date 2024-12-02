namespace CustomizeStateMachine
{
    using UnityEngine;
    using System;
    using System.Collections;
    public interface IDamageable
    {
        void TakeDamage(Vector3 hitPosition,float amount, GameObject source);
        
    }
}