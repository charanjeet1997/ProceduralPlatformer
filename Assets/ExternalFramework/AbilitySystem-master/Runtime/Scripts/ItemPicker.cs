namespace CustomizeStateMachine
{
    using UnityEngine;
  
    public class ItemPicker : MonoBehaviour, IItemPicker
    {
        private void OnTriggerEnter(Collider other)
        {
            var item = other.GetComponent<IPickable>();
            if (item != null)
            {
                PickUpItem(item);
            }
        }

        public void PickUpItem(IPickable pickedUpItem)
        {
            // Implement the logic to handle the item pickup.
            // For example, adding the item to the hero's inventory or applying its effects directly.
            pickedUpItem.HandlePickup(gameObject);
        }
    }
}