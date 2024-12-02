namespace CustomizeStateMachine
{
    using UnityEngine;

    public interface IPickable
    {
        void HandlePickup(GameObject baseHero);
    }
    
    public interface IItemPicker 
    {
        void PickUpItem(IPickable item);
    }
}