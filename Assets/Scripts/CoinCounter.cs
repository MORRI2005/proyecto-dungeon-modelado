using System;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{

    [SerializeField] private Inventory _inventory;
    [SerializeField] private TMP_Text coinText;

    private Animator _coinAnimator;
    void Awake()
    {
        _inventory.OnInventoryUpdated += UpdateCounter;
    }
    void Start()
    {
        coinText.text = _inventory.GetCoins().ToString();
        _coinAnimator = GetComponent<Animator>();
    }


    void UpdateCounter()
    {
        coinText.text = _inventory.GetCoins().ToString();
        _coinAnimator.SetTrigger("PickUp");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
