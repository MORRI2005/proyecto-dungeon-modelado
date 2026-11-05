using UnityEngine;

public class CoinPickup : PickupBase
{
    protected override void PickupEffect(Picker _picker)
    {

        // Actualizamos el picker del inventory
        Inventory inventory = _picker.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddOrSubstractCoins(1);
        }
    }
}
