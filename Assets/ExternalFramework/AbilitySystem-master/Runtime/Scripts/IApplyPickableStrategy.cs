namespace CustomizeStateMachine
{
    using UnityEngine;
    using System;
    using System.Collections;

    public interface IApplyPickableStrategy
    {
        void ApplyBoostEffect(Transform parentTransform);
    }
}