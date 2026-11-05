using UnityEngine;
using UnityEngine.Events;

public abstract class PickupBase : MonoBehaviour
{
    public UnityAction OnPickup;
    public bool pickupEnabled = true;

    protected abstract void PickupEffect(Picker _picker);

    void Start()
    {
        Picker.Instance.AddPickup(this);
    }

    void OnDestroy()
    {
        if (Picker.Instance != null)
        {
            Picker.Instance.RemovePickup(this);
        }
    }

    // Recibimos quien lo pilla
    public void PickUp(Picker _picker)
    {
        if (!pickupEnabled) return;

        OnPickup?.Invoke();

        pickupEnabled = false;

        gameObject.SetActive(false);

        PickupEffect(_picker);
    }
}
