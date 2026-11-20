using UnityEngine;

public class PotionPickup : PickupBase
{
    protected override void PickupEffect(Picker _picker)
    {

        // Actualizamos el picker del inventory
        Inventory inventory = _picker.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddOrSubstractPotions(1);
        }
    }
}
