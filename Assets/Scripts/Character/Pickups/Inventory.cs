using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{

    [SerializeField] int coins;
    [SerializeField] int potions;

    [SerializeField] int keys;

    [SerializeField] bool hasKeyA;

    [SerializeField] bool hasKeyB;

    [SerializeField] bool hasShield;


    public UnityAction OnInventoryUpdated;

    public int GetCoins()
    {
        return coins;
    }

    public int GetPotions()
    {
        return potions;
    }

    public int GetKeys()
    {
        return keys;
    }
    public void AddOrSubstractCoins(int amount)
    {
        coins += amount;
        OnInventoryUpdated?.Invoke();
    }

    public void AddOrSubstractPotions(int amount)
    {
        potions += amount;
        OnInventoryUpdated?.Invoke();
        Debug.Log("Potions: " + potions);
    }

    public void AddOrSubstractKeys(int amount)
    {
        keys += amount;
        OnInventoryUpdated?.Invoke();
        Debug.Log("Keys: " + keys);
    }

    public void AddShield(bool value)
    {
        hasShield = value;
        OnInventoryUpdated?.Invoke();
        Debug.Log("Shield: " + hasShield);
    }

}
